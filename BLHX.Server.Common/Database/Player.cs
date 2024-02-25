using BLHX.Server.Common.Proto.common;
using BLHX.Server.Common.Proto.p12;
using BLHX.Server.Common.Proto.p13;
using BLHX.Server.Common.Utils;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BLHX.Server.Common.Database
{
    public sealed class PlayerContext : DbContext, IBLHXDBContext<PlayerContext>
    {
        SavingState savingState;
        public static string DbPath => "Databases/players.db";
        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerResource> Resources { get; set; }
        public DbSet<ResourceField> ResourceFields { get; set; }
        public DbSet<PlayerShip> Ships { get; set; }
        public DbSet<ChapterInfo> ChapterInfoes { get; set; }

        public PlayerContext()
        {
            if (Database.GetPendingMigrations().Any())
                Database.Migrate();

            SavingChanges += (_, _) => savingState = SavingState.Saving;
            SavedChanges += (_, _) => savingState = SavingState.None;
            SaveChangesFailed += (_, _) => savingState = SavingState.None;
        }

        // Thread-safe method pls
        public void Save()
        {
            if (savingState == SavingState.Attempting) 
                return;

            while (savingState != SavingState.None)
            {
                savingState = SavingState.Attempting;
                Task.Delay(1).Wait();
            }

            SaveChanges();
        }

        public Player Init(string token, uint shipId, string name)
        {
            var player = new Player(token, new Displayinfo() { Icon = shipId }, name);

            Players.Add(player);
            Save();

            // Initial resousrces
            player.DoResource(8, 4000);
            player.DoResource(7, 5);
            player.DoResource(5, 5);
            player.DoResource(2, 500);
            player.DoResource(1, 3000);

            // Selected ship and Long Island as default...
            player.AddShip(shipId);
            player.AddShip(106011);

            PlayerRoutine(player);

            return player;
        }

        public void PlayerRoutine(Player player)
        {
            if (!ResourceFields.Any(x => x.Type == ResourceFieldType.Gold))
                ResourceFields.Add(new() { Type = ResourceFieldType.Gold, PlayerUid = player.Uid });
            if (!ResourceFields.Any(x => x.Type == ResourceFieldType.Oil))
                ResourceFields.Add(new() { Type = ResourceFieldType.Oil, PlayerUid = player.Uid });

            Save();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Player>(e =>
            {
                e.Property(b => b.DisplayInfo)
                .HasJsonConversion();
                e.Property(b => b.Fleets)
                .HasJsonConversion()
                .HasDefaultValue(new List<Groupinfo>() {
                    new() { Id = 1, ShipLists = [1, 2] },
                    new() { Id = 2 },
                    new() { Id = 11 },
                    new() { Id = 12 }
                });
                e.Property(b => b.ShipSkins)
                .HasJsonConversion()
                .HasDefaultValue(new List<Idtimeinfo>() { });
                e.Property(b => b.Adv)
                .HasDefaultValue("");
                e.HasMany(b => b.Resources)
                .WithOne(e => e.Player)
                .HasForeignKey(e => e.PlayerUid)
                .IsRequired();
                e.HasMany(b => b.ResourceFields)
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
            modelBuilder.Entity<ChapterInfo>(e =>
            {
                e.Property(x => x.EscortLists)
                .HasJsonConversion();
                e.Property(x => x.AiLists)
                .HasJsonConversion();
                e.Property(x => x.BuffLists)
                .HasJsonConversion();
                e.Property(x => x.GroupLists)
                .HasJsonConversion();
                e.Property(x => x.BattleStatistics)
                .HasJsonConversion();
                e.Property(x => x.CellFlagLists)
                .HasJsonConversion();
                e.Property(x => x.CellLists)
                .HasJsonConversion();
                e.Property(x => x.ChapterStrategyLists)
                .HasJsonConversion();
                e.Property(x => x.ExtraFlagLists)
                .HasJsonConversion();
                e.Property(x => x.FleetDuties)
                .HasJsonConversion();
                e.Property(x => x.OperationBuffs)
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
        // Aka. manifesto
        public string Adv { get; set; } = string.Empty;
        public uint Level { get; set; }
        // TODO: Exp add setter to recalculate cap and set level
        public uint Exp { get; set; }
        public Displayinfo DisplayInfo { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<Groupinfo> Fleets { get; set; } = null!;
        public List<Idtimeinfo> ShipSkins { get; set; } = null!;
        public uint? CurrentChapter { get; set; }

        public virtual ICollection<PlayerResource> Resources { get; set; } = [];
        public virtual ICollection<ResourceField> ResourceFields { get; set; } = [];
        public virtual ICollection<PlayerShip> Ships { get; set; } = [];
        public virtual ICollection<ChapterInfo> ChapterInfoes { get; set; } = [];

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

        public void HarvestResourceField(ResourceFieldType type)
        {
            foreach (var resourceField in ResourceFields)
            {
                if (resourceField.Type == type)
                {
                    var amount = resourceField.Flush();
                    switch (type)
                    {
                        case ResourceFieldType.Gold:
                            DoResource(1, (int)amount);
                            break;
                        case ResourceFieldType.Oil:
                            DoResource(2, (int)amount);
                            break;
                    }

                    resourceField.CalculateYield();
                }
            }
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

    public enum ResourceFieldType
    {
        Gold = 1,
        Oil = 2
    }

    [PrimaryKey(nameof(Type), nameof(PlayerUid))]
    public class ResourceField
    {
        [Key]
        public ResourceFieldType Type { get; set; }
        public uint Level { get; set; } = 1;
        public DateTime LastHarvestTime { get; set; } = DateTime.Now;
        public DateTime UpgradeTime { get; set; } = DateTime.Now;

        [Key]
        public uint PlayerUid { get; set; }
        public virtual Player Player { get; set; } = null!;

        public void CalculateYield()
        {
            // TODO: Take UpgradeTime into acccount of the reward
            switch (Type)
            {
                case ResourceFieldType.Gold:
                    if (Data.Data.GoldFieldTemplate.TryGetValue((int)Level, out var goldTemplate))
                    {
                        var res = Player.Resources.FirstOrDefault(x => x.Id == 7);
                        var num = (goldTemplate.HourTime * goldTemplate.Production) / 3600f * LastHarvestTime.GetSecondsPassed();

                        if (res is not null)
                            res.Num = Math.Min((uint)Math.Floor(num), goldTemplate.Store);
                    }
                    break;
                case ResourceFieldType.Oil:
                    if (Data.Data.OilFieldTemplate.TryGetValue((int)Level, out var oilTemplate))
                    {
                        var res = Player.Resources.FirstOrDefault(x => x.Id == 5);
                        var num = (oilTemplate.HourTime * oilTemplate.Production) / 3600f * LastHarvestTime.GetSecondsPassed();

                        if (res is not null)
                            res.Num = Math.Min((uint)Math.Floor(num), oilTemplate.Store);
                    }
                    break;
            }
        }

        public uint Flush()
        {
            uint amount = 0;
            // TODO: Take UpgradeTime into acccount of the reward
            switch (Type)
            {
                case ResourceFieldType.Gold:
                    if (Data.Data.GoldFieldTemplate.TryGetValue((int)Level, out var goldTemplate))
                    {
                        var goldField = Player.Resources.First(x => x.Id == 7);
                        amount = goldField.Num;

                        goldField.Num = 0;
                    }
                    break;
                case ResourceFieldType.Oil:
                    if (Data.Data.OilFieldTemplate.TryGetValue((int)Level, out var oilTemplate))
                    {
                        var oilField = Player.Resources.First(x => x.Id == 5);
                        amount = oilField.Num;

                        oilField.Num = 0;
                    }
                    break;
            }
            LastHarvestTime = DateTime.Now;

            return amount;
        }
    }

    [PrimaryKey(nameof(Id), nameof(PlayerUid))]
    public class ChapterInfo
    {
        [Key]
        public uint Id { get; set; }
        public DateTime Time { get; set; }
        public List<Chaptercellinfo> CellLists { get; set; } = [];
        public List<Groupinchapter> GroupLists { get; set; } = [];
        public List<Chaptercellinfo> AiLists { get; set; } = [];
        public List<Chaptercellinfo> EscortLists { get; set; } = [];
        public uint Round { get; set; }
        public bool IsSubmarineAutoAttack { get; set; }
        public List<uint> OperationBuffs { get; set; } = [];
        public uint ModelActCount { get; set; }
        public List<uint> BuffLists { get; set; } = [];
        public uint LoopFlag { get; set; }
        public List<uint> ExtraFlagLists { get; set; } = [];
        public List<Cellflag> CellFlagLists { get; set; } = [];
        public uint ChapterHp { get; set; }
        public List<Strategyinfo> ChapterStrategyLists { get; set; } = [];
        public uint KillCount { get; set; }
        public uint InitShipCount { get; set; }
        public uint ContinuousKillCount { get; set; }
        public List<Strategyinfo> BattleStatistics { get; set; } = [];
        public List<fleetDutykeyValuePair> FleetDuties { get; set; } = [];
        public uint MoveStepCount { get; set; }

        [Key]
        public uint PlayerUid { get; set; }
        public virtual Player Player { get; set; } = null!;

        public Currentchapterinfo ToProto()
        {
            return new Currentchapterinfo()
            {
                Id = Id,
                AiLists = AiLists,
                BattleStatistics = BattleStatistics,
                BuffLists = BuffLists,
                CellFlagLists = CellFlagLists,
                CellLists = CellLists,
                ChapterHp = ChapterHp, 
                ChapterStrategyLists = ChapterStrategyLists,
                ContinuousKillCount = ContinuousKillCount,
                EscortLists = EscortLists,
                ExtraFlagLists = ExtraFlagLists,
                FleetDuties = FleetDuties,
                GroupLists = GroupLists,
                InitShipCount = InitShipCount,
                IsSubmarineAutoAttack = Convert.ToUInt32(IsSubmarineAutoAttack),
                KillCount = KillCount,
                LoopFlag = LoopFlag,
                ModelActCount = ModelActCount,
                MoveStepCount = MoveStepCount,
                OperationBuffs = OperationBuffs,
                Round = Round,
                Time = (uint)new DateTimeOffset(Time).ToUnixTimeSeconds()
            };
        }
    }
}
