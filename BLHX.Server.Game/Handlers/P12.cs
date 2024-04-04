using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p12;
using BLHX.Server.Common.Utils;
using BLHX.Server.Common.Proto.common;

namespace BLHX.Server.Game.Handlers {
    internal static class P12 {
        [PacketHandler(Command.Cs12102, SaveDataAfterRun = true)]
        static void UpdateFleetHandler(Connection connection, Packet packet) {
            var fleet = packet.Decode<Cs12102>();
            var toUpdate = connection.player.Fleets.Find(x => x.Id == fleet.Id);

            if (toUpdate is not null)
                toUpdate.ShipLists = fleet.ShipLists;
            else
                connection.player.Fleets.Add(new() { Id = fleet.Id, ShipLists = fleet.ShipLists });

            connection.Send(new Sc12103());
        }

        [PacketHandler(Command.Cs12202, SaveDataAfterRun = true)]
        static void SetShipSkinHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs12202>();
            if (connection.player.Ships.Any(x => x.Id == req.ShipId))
                connection.player.Ships.First(x => x.Id == req.ShipId).SkinId = req.SkinId;

            connection.Send(new Sc12203());
        }

        [PacketHandler(Command.Cs12002, SaveDataAfterRun = true)]
        static void UseResourceHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs12002>();

            Logger.c.Log("Id: " + req.Id);
            Logger.c.Log("Cost Type: " + req.Costtype);
            Logger.c.Log("Count: " + req.Count);



            connection.Send(new Sc12003() {
                BuildInfoes = [
                    new Buildinfo() { BuildId = req.Id, FinishTime = 0, Time = 0 },
                ]
            });
        }

        [PacketHandler(Command.Cs12008, SaveDataAfterRun = true)]
        static void FinishAllBuildHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs12008>();

            connection.Send(new Sc12009() { PosLists = req.PosLists });
        }

    }

    static class P12ConnectionNotifyExtensions {
        public static void NotifyShipData(this Connection connection) {
            if (connection.player is not null) {
                connection.Send(new Sc12001() {
                    Shiplists = connection.player.Ships.Select(x => x.ToProto()).ToList()
                });
            }
        }

        public static void NotifyShipSkinData(this Connection connection) {
            connection.Send(new Sc12201() { SkinLists = connection.player.ShipSkins });
        }

        public static void NotifyFleetData(this Connection connection) {
            if (connection.player is not null) {
                connection.Send(new Sc12101() {
                    GroupLists = connection.player.Fleets
                });
            }

        }

        public static void NotifyBuildShipData(this Connection connection) {
            connection.Send(new Sc12024());
        }
    }
}
