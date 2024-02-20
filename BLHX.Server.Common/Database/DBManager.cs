using BLHX.Server.Common.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection;
using System.Text.Json;

namespace BLHX.Server.Common.Database
{
    public static class DBManager
    {
        public static readonly Logger c = new(nameof(DBManager), ConsoleColor.DarkCyan);
        public static AccountContext AccountContext { get; }
        public static PlayerContext PlayerContext { get; }

        static DBManager()
        {
            foreach (var dbCtx in Assembly.GetExecutingAssembly().GetTypes().Where(p => typeof(IBLHXDBContext).IsAssignableFrom(p) && !p.IsInterface))
            {
                var dbPath = (string)dbCtx.GetProperty(nameof(AccountContext.DbPath))!.GetValue(null)!;
                var saveDir = Path.GetDirectoryName(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, dbPath))!;
                if (!Directory.Exists(saveDir))
                    Directory.CreateDirectory(saveDir);
            }

            AccountContext = new AccountContext();
            PlayerContext = new PlayerContext();
        }
    }

    public interface IBLHXDBContext
    {
        public static abstract string DbPath { get; }
        public string GetFullDbPath();
    }

    public interface IBLHXDBContext<TSelf> : IBLHXDBContext where TSelf : DbContext
    {
        string IBLHXDBContext.GetFullDbPath() => Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, (string)typeof(TSelf).GetProperty(nameof(DbPath))!.GetValue(null)!);
    }

    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<T> HasJsonConversion<T>(this PropertyBuilder<T> propertyBuilder) where T : class, new()
        {
            ValueConverter<T, string> converter = new
            (
                v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                v => JsonSerializer.Deserialize<T>(v, JsonSerializerOptions.Default) ?? new T()
            );

            propertyBuilder.HasConversion(converter);
            propertyBuilder.Metadata.SetValueConverter(converter);
            propertyBuilder.HasColumnType("jsonb");

            return propertyBuilder;
        }
    }
}
