using BLHX.Server.Common.Utils;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BLHX.Server.Common.Database
{
    public static class DBManager
    {
        public static readonly Logger c = new(nameof(DBManager), ConsoleColor.DarkCyan);
        public static AccountContext AccountContext { get; }

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
}
