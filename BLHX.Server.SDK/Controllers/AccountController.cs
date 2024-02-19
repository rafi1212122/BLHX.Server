using BLHX.Server.Common.Database;
using BLHX.Server.Sdk;
using BLHX.Server.SDK.Models;

namespace BLHX.Server.SDK.Controllers
{
    public class AccountController : IRegisterable
    {
        public static void Register(WebApplication app)
        {
            app.MapPost("user/create", (HttpContext ctx, UserCreateRequest req) =>
            {
                var account = DBManager.AccountContext.Accounts.SingleOrDefault(x => x.DeviceId == req.DeviceId);

                UserCreateResponse rsp = new() { Result = 0, IsNew = 0 };
                if (account is null)
                {
                    account = new(req.DeviceId, Guid.NewGuid().ToString());
                    DBManager.AccountContext.Add(account);
                    DBManager.AccountContext.SaveChanges();
                    rsp.IsNew = 1;
                }
                rsp.Uid = account.Uid;
                rsp.Token = account.Token;

                return ctx.Response.WriteAsJsonAsync(rsp);
            });

            app.MapPost("user/login", (HttpContext ctx, UserLoginRequest req) =>
            {
                var account = DBManager.AccountContext.Accounts.SingleOrDefault(x => x.Uid == req.Uid);

                if (account is not null && account.Token == req.Token)
                {
                    return ctx.Response.WriteAsJsonAsync(new UserLoginResponse()
                    {
                        AccessToken = account.Token,
                        Birth = null,
                        ChannelId = req.StoreId,
                        CurrentTimestampMs = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
                        KrKmcStatus = 2,
                        Result = 0,
                        TransCode = "NULL"
                    });
                }
                return ctx.Response.WriteAsJsonAsync(new BaseResponse() { Result = 1 });
            });
        }
    }
}
