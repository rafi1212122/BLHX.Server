using BLHX.Server.Common.Database;
using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p11;

namespace BLHX.Server.Game.Handlers {
    internal static class P11 {
        [PacketHandler(Command.Cs11001)]
        static void ServerTimeHandler(Connection connection, Packet packet) {
            connection.InitClientData();
            connection.Send(new Sc11002() {
                Timestamp = (uint)DateTimeOffset.Now.ToUnixTimeSeconds(),
                Monday0oclockTimestamp = Connection.Monday0oclockTimestamp,
                ShipCount = connection.player is null ? 0 : (uint)connection.player.Ships.Count
            });
            connection.Tick();
        }

        [PacketHandler(Command.Cs11009, SaveDataAfterRun = true)]
        static void ChangeManifestoHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs11009>();
            connection.player.Adv = req.Adv;

            connection.Send(new Sc11010());
        }

        [PacketHandler(Command.Cs11013, SaveDataAfterRun = true)]
        static void HarvestResourceHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs11013>();
            connection.player.HarvestResourceField((ResourceFieldType)req.Type);

            connection.Send(new Sc11014());
        }

        [PacketHandler(Command.Cs11019, SaveDataAfterRun = true)]
        static void UpdateCommonFlagHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs11019>();

            connection.Send(new Sc11020());
        }

        [PacketHandler(Command.Cs11601)]
        static void GetEmojiInfoHandler(Connection connection, Packet packet) {
            connection.Send(new Sc11602());
        }

        [PacketHandler(Command.Cs11603)]
        static void FetchSecondaryPasswordHandler(Connection connection, Packet packet) {
            connection.Send(new Sc11604());
        }

        [PacketHandler(Command.Cs11017)]
        static void StageDropListHandler(Connection connection, Packet packet) {
            connection.Send(new Sc11018());
        }

        [PacketHandler(Command.Cs11401)]
        static void ChangeChatRoomHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs11401>();

            connection.Send(new Sc11402() {
                Result = 0,
                RoomId = req.RoomId
            });
        }
    }

    static class P11ConnectionNotifyExtensions {
        public static void NotifyResourceList(this Connection connection) {
            if (connection.player is not null) {
                connection.Send(new Sc11004() {
                    ResourceLists = connection.player.Resources.Select(x => new Resource() { Num = x.Num, Type = x.Id }).ToList()
                });
            }
        }

        public static void NotifyPlayerData(this Connection connection) {
            if (connection.player is not null) {
                connection.Send(new Sc11003() {
                    Id = connection.player.Uid,
                    Name = connection.player.Name,
                    Level = connection.player.Level,
                    Exp = connection.player.Exp,
                    Adv = connection.player.Adv,
                    ResourceLists = connection.player.Resources.Select(x => new Resource() { Num = x.Num, Type = x.Id }).ToList(),
                    Characters = connection.player.Characters,
                    WinCount = connection.player.WinCount,
                    AttackCount = connection.player.AttackCount,
                    ShipBagMax = connection.player.ShipBagMax,
                    EquipBagMax = connection.player.EquipBagMax,
                    GmFlag = connection.player.GmFlag,
                    Rank = connection.player.Rank,
                    PvpAttackCount = connection.player.PvpAttackCount,
                    PvpWinCount = connection.player.PvpWinCount,
                    CollectAttackCount = connection.player.CollectAttackCount,
                    GuideIndex = connection.player.GuideIndex,
                    BuyOilCount = connection.player.BuyOilCount,
                    ChatRoomId = connection.player.ChatRoomId,
                    MaxRank = connection.player.MaxRank,
                    AccPayLv = connection.player.AccPayLv,
                    GuildWaitTime = connection.player.GuildWaitTime,
                    ChatMsgBanTime = connection.player.ChatMsgBanTime,
                    ThemeUploadNotAllowedTime = connection.player.ThemeUploadNotAllowedTime,
                    RandomShipMode = connection.player.RandomShipMode,
                    MarryShip = connection.player.MarryShip,
                    ChildDisplay = connection.player.ChildDisplay,
                    StoryLists = connection.player.StoryLists,
                    FlagLists = connection.player.FlagLists,
                    MedalIds = connection.player.MedalIds,
                    CartoonReadMarks = connection.player.CartoonReadMarks,
                    CartoonCollectMarks = connection.player.CartoonCollectMarks,
                    RandomShipLists = connection.player.RandomShipLists,
                    Soundstories = connection.player.Soundstories,
                    CardLists = connection.player.CardLists,
                    CdLists = connection.player.CdLists,
                    IconFrameLists = connection.player.IconFrameLists,
                    ChatFrameLists = connection.player.ChatFrameLists,
                    RefundShopInfoLists = connection.player.RefundShopInfoLists,
                    TakingShipLists = connection.player.TakingShipLists,
                    RegisterTime = (uint)new DateTimeOffset(connection.player.CreatedAt).ToUnixTimeSeconds(),
                    ShipCount = connection.player.ShipCount,
                    CommanderBagMax = connection.player.CommanderBagMax,
                    Display = connection.player.DisplayInfo,
                    Appreciation = connection.player.Appreciation,
                });
            }
        }

        public static void NotifyRefluxData(this Connection connection) {
            connection.Send(new Sc11752());
        }

        public static void NotifyActivityData(this Connection connection) {
            connection.Send(new Sc11200());
        }
    }
}
