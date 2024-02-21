using BLHX.Server.Common.Database;
using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p11;

namespace BLHX.Server.Game.Handlers
{
    internal static class P11
    {
        [PacketHandler(Command.Cs11001)]
        static void ServerTimeHandler(Connection connection, Packet packet)
        {
            connection.InitClientData();
            connection.Send(new Sc11002()
            {
                Timestamp = (uint)DateTimeOffset.Now.ToUnixTimeSeconds(),
                Monday0oclockTimestamp = Connection.Monday0oclockTimestamp,
                ShipCount = connection.player is null ? 0 : (uint)connection.player.Ships.Count
            });
        }

        [PacketHandler(Command.Cs11009)]
        static void ChangeManifestoHandler(Connection connection, Packet packet)
        {
            var req = packet.Decode<Cs11009>();
            connection.player.Adv = req.Adv;
            DBManager.PlayerContext.SaveChanges();

            connection.Send(new Sc11010());
        }

        [PacketHandler(Command.Cs11601)]
        static void GetEmojiInfoHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc11602());
        }

        [PacketHandler(Command.Cs11603)]
        static void FetchSecondaryPasswordHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc11604());
        }

        [PacketHandler(Command.Cs11017)]
        static void StageDropListHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc11018());
        }

        [PacketHandler(Command.Cs11401)]
        static void ChangeChatRoomHandler(Connection connection, Packet packet)
        {
            var req = packet.Decode<Cs11401>();

            connection.Send(new Sc11402()
            {
                Result = 0,
                RoomId = req.RoomId
            });
        }
    }

    static class P11ConnectionNotifyExtensions
    {
        public static void NotifyPlayerData(this Connection connection)
        {
            if (connection.player is not null)
            {
                connection.Send(new Sc11003()
                {
                    Id = connection.player.Uid,
                    Name = connection.player.Name,
                    Level = connection.player.Level,
                    Exp = connection.player.Exp,
                    Adv = connection.player.Adv,
                    ResourceLists = connection.player.Resources.Select(x => new Resource() { Num = x.Num, Type = x.Id }).ToList(),
                    Characters = [1],
                    ShipBagMax = 150,
                    EquipBagMax = 350,
                    GmFlag = 1,
                    Rank = 1,
                    GuideIndex = 1000000,
                    ChatRoomId = 1,
                    RegisterTime = (uint)new DateTimeOffset(connection.player.CreatedAt).ToUnixTimeSeconds(),
                    ShipCount = (uint)connection.player.Ships.Count,
                    CommanderBagMax = 40,
                    Display = connection.player.DisplayInfo,
                    Appreciation = new()
                });
            }
        }

        public static void NotifyRefluxData(this Connection connection)
        {
            connection.Send(new Sc11752());
        }
    }
}
