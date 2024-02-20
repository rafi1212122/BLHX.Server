using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLHX.Server.Common.Database
{
    public sealed class AccountContext : DbContext, IBLHXDBContext<AccountContext>
    {
        public static string DbPath => "Databases/accounts.db";
        public DbSet<Account> Accounts { get; set; }

        public AccountContext()
        {
            if (Database.GetPendingMigrations().Any())
                Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={((IBLHXDBContext)this).GetFullDbPath()}");
    }

    [PrimaryKey(nameof(Uid))]
    public class Account
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Uid { get; set; }
        public string DeviceId { get; set; }
        public string Token { get; set; }

        public Account(string deviceId, string token)
        {
            DeviceId = deviceId;
            Token = token;
        }
    }
}
