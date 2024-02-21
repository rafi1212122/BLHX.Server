using BLHX.Server.Common.Proto.common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLHX.Server.Common.Database
{
    public sealed class PlayerContext : DbContext, IBLHXDBContext<PlayerContext>
    {
        public static string DbPath => "Databases/players.db";
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerResource> Resources { get; set; }
        public DbSet<PlayerShip> Ships { get; set; }

        public PlayerContext()
        {
            if (Database.GetPendingMigrations().Any())
                Database.Migrate();
        }

        public Player Init(string token, uint shipId, string name)
        {
            var player = new Player(token, new Displayinfo() { Icon = shipId }, name);

            Players.Add(player);
            SaveChanges();

            // Initial resousrces
            player.DoResource(8, 4000);
            player.DoResource(7, 5);
            player.DoResource(5, 5);
            player.DoResource(2, 500);
            player.DoResource(1, 3000);

            // Selected ship and Long Island as default...
            player.AddShip(shipId);
            player.AddShip(106011);

            SaveChanges();

            return player;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>(e =>
            {
                e.Property(b => b.DisplayInfo)
                .HasJsonConversion();
                e.HasMany(b => b.Resources)
                .WithOne(e => e.Player)
                .HasForeignKey(e => e.PlayerUid)
                .IsRequired();
                e.HasMany(b => b.Ships)
                .WithOne(e => e.Player)
                .HasForeignKey(e => e.PlayerUid)
                .IsRequired();
            });
            modelBuilder.Entity<PlayerShip>(e =>
            {
                e.Property(b => b.Id)
                .ValueGeneratedOnAdd();
                e.Property(b => b.State)
                .HasJsonConversion();
                e.Property(b => b.EquipInfoLists)
                .HasJsonConversion();
                e.Property(b => b.TransformLists)
                .HasJsonConversion();
                e.Property(b => b.SkillIdLists)
                .HasJsonConversion();
                e.Property(b => b.StrengthLists)
                .HasJsonConversion();
                e.Property(b => b.MetaRepairLists)
                .HasJsonConversion();
                e.Property(b => b.CoreLists)
                .HasJsonConversion();
            });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseLazyLoadingProxies()
            .EnableSensitiveDataLogging()
            .UseSqlite($"Data Source={((IBLHXDBContext)this).GetFullDbPath()}");
    }

    [PrimaryKey(nameof(Uid))]
    [Index(nameof(Token), IsUnique = true)]
    public class Player
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public uint Uid { get; set; }
        public string Token { get; set; }
        public string Name { get; set; }
        public uint Level { get; set; }
        // TODO: Exp add setter to recalculate cap and set level
        public uint Exp { get; set; }
        public Displayinfo DisplayInfo { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<PlayerResource> Resources { get; set; } = [];
        public virtual ICollection<PlayerShip> Ships { get; set; } = [];

        public Player(string token, Displayinfo displayInfo, string name)
        {
            DisplayInfo = displayInfo;
            Token = token;
            Name = name;
            Level = 1;
            CreatedAt = DateTime.Now;
        }

        public void DoResource(uint id, int num)
        {
            var res = Resources.SingleOrDefault(x => x.Id == id);
            if (res is null)
            {
                res = new() { Id = id, PlayerUid = Uid };
                DBManager.PlayerContext.Resources.Add(res);
            }

            if (num < 0)
                res.Num = (uint)Math.Max(res.Num - num, 0);
            else
                res.Num = Math.Min(res.Num + (uint)num, uint.MaxValue);
        }

        public void AddShip(uint shipTemplateId)
        {
            if (!Data.Data.ShipDataTemplate.TryGetValue((int)shipTemplateId, out var shipTemplate))
                throw new InvalidDataException($"Ship template {shipTemplateId} not found!");

            var ship = new PlayerShip()
            {
                TemplateId = shipTemplateId,
                Level = 1,
                EquipInfoLists = [
                    new EquipskinInfo() { Id = shipTemplate.EquipId1 },
                    new EquipskinInfo() { Id = shipTemplate.EquipId2 },
                    new EquipskinInfo() { Id = shipTemplate.EquipId3 },
                    new EquipskinInfo(),
                    new EquipskinInfo(),
                ],
                Energy = shipTemplate.Energy,
                // I'm not sure if buff_list in template refer to this thing
                SkillIdLists = shipTemplate.BuffList.Select(x => new Shipskill() { SkillId = x, SkillLv = 1 }).ToList(),
                //Idk if this is really the default
                Intimacy = 5000,

                PlayerUid = Uid
            };

            DBManager.PlayerContext.Ships.Add(ship);
        }
    }

    [PrimaryKey(nameof(Id), nameof(PlayerUid))]
    public class PlayerResource
    {
        [Key]
        public uint Id { get; set; }
        public uint Num { get; set; }

        [Key]
        public uint PlayerUid { get; set; }
        public virtual Player Player { get; set; } = null!;
    }

    [PrimaryKey(nameof(Id))]
    public class PlayerShip
    {
        [Key]
        public uint Id { get; set; }
        public uint TemplateId { get; set; }
        public uint Level { get; set; }
        // TODO: Exp add setter to recalculate cap and set level
        public uint Exp { get; set; }
        public List<EquipskinInfo> EquipInfoLists { get; set; } = [];
        public uint Energy { get; set; }
        public Shipstate State { get; set; } = new Shipstate() { State = 1, StateInfo1 = 1 };
        public bool IsLocked { get; set; }
        public List<TransformInfo> TransformLists { get; set; } = [];
        public List<Shipskill> SkillIdLists { get; set; } = [];
        public uint Intimacy { get; set; }
        public uint Proficiency { get; set; }
        public List<StrengthInfo> StrengthLists { get; set; } = [];
        public uint SkinId { get; set; }
        public uint Propose { get; set; }
        public string? Name { get; set; }
        public uint CommanderId { get; set; }
        public uint BluePrintFlag { get; set; }
        public uint? CommonFlag { get; set; }
        public uint ActivityNpc { get; set; }
        public List<uint> MetaRepairLists { get; set; } = [];
        public List<Shipcoreinfo> CoreLists { get; set; } = [];

        public uint PlayerUid { get; set; }
        public virtual Player Player { get; set; } = null!;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? LastChangeName { get; set; }

        public Shipinfo ToProto()
        {
            return new()
            {
                Id = Id,
                TemplateId = TemplateId,
                Level = Level,
                Exp = Exp,
                EquipInfoLists = EquipInfoLists,
                Energy = Energy,
                State = State,
                IsLocked = Convert.ToUInt32(IsLocked),
                TransformLists = TransformLists,
                SkillIdLists = SkillIdLists,
                Intimacy = Intimacy,
                Proficiency = Proficiency,
                StrengthLists = StrengthLists,
                CreateTime = (uint)new DateTimeOffset(CreatedAt).ToUnixTimeSeconds(),
                SkinId = SkinId,
                Propose = Propose,
                Name = Name,
                ChangeNameTimestamp = LastChangeName is null ? 0 : (uint)new DateTimeOffset((DateTime)LastChangeName).ToUnixTimeSeconds(),
                Commanderid = CommanderId,
                MaxLevel = Data.Data.ShipDataTemplate[(int)TemplateId].MaxLevel,
                BluePrintFlag = BluePrintFlag,
                CommonFlag = CommonFlag ?? default,
                ActivityNpc = ActivityNpc,
                MetaRepairLists = MetaRepairLists,
                CoreLists = CoreLists
            };
        }
    }
}
