using BLHX.Server.Common.Utils;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Reflection;

namespace BLHX.Server.Sdk
{
    public class SDKServer
    {
        public static readonly Logger c = new(nameof(SDKServer), ConsoleColor.Green);
        static Task? runTask = null;

        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Disables default logger
            builder.Logging.ClearProviders();
            builder.Services.AddMvcCore();
            builder.Services.AddAntiforgery();

            var app = builder.Build();
            app.Urls.Add("http://*:80");
            app.Urls.Add("https://*:443");

            app.UseStatusCodePages();
            app.UseAntiforgery();
            app.UseMiddleware<RequestLoggingMiddleware>();

            foreach (Type controller in Assembly.GetExecutingAssembly().GetTypes().Where(p => typeof(IRegisterable).IsAssignableFrom(p) && !p.IsInterface))
            {
                controller.GetMethod(nameof(IRegisterable.Register))!.Invoke(null, new object[] { app });
#if DEBUG
                c.Log($"Registered HTTP controller '{controller.Name}'");
#endif
            }

            runTask = app.RunAsync();
            c.Log($"{nameof(SDKServer)} started on port {string.Join(", ", app.Urls.Select(x => x.Split(':').Last()))}");
        }

        private class RequestLoggingMiddleware(RequestDelegate next)
        {
            private readonly RequestDelegate _next = next;
            private static readonly string[] SurpressedRoutes = [];

            public async Task Invoke(HttpContext context)
            {
                try
                {
                    await _next(context);
                }
                catch (Exception ex)
                {
#if DEBUG
                    c.Error($"{ex} Request below:");
#else
                    c.Error($"{ex.Message} Request below:");
#endif
                }
                finally
                {
                    c.Log($"{context.Response.StatusCode} {context.Request.Method.ToUpper()} {context.Request.Path + context.Request.QueryString}");
                }
            }
        }
    }

    public interface IRegisterable
    {
        public abstract static void Register(WebApplication app);
    }

    public static class BindingExtensions
    {
        public static async Task<T?> BindFromForm<T>(this HttpContext httpContext)
        {
            var serviceProvider = httpContext.RequestServices;
            var factory = serviceProvider.GetRequiredService<IModelBinderFactory>();
            var metadataProvider = serviceProvider.GetRequiredService<IModelMetadataProvider>();

            var metadata = metadataProvider.GetMetadataForType(typeof(T));
            var modelBinder = factory.CreateBinder(new()
            {
                Metadata = metadata
            });

            var context = new DefaultModelBindingContext
            {
                ModelMetadata = metadata,
                ModelName = string.Empty,
                ValueProvider = new FormValueProvider(
                    BindingSource.Form,
                    httpContext.Request.Form,
                    CultureInfo.InvariantCulture
                ),
                ActionContext = new ActionContext(
                    httpContext,
                    new RouteData(),
                    new ActionDescriptor()),
                ModelState = new ModelStateDictionary()
            };
            await modelBinder.BindModelAsync(context);
            return (T?)context.Result.Model;
        }
    }

    public abstract record BindableFormRequest<TSelf>
    {
        public static async ValueTask<TSelf?> BindAsync(HttpContext httpContext, ParameterInfo parameter)
        {
            return await httpContext.BindFromForm<TSelf>();
        }
    }
}
