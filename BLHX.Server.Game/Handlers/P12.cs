using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p12;
using BLHX.Server.Common.Utils;
using BLHX.Server.Common.Proto.common;
using BLHX.Server.Common.Proto.p11;
using BLHX.Server.Common.Data;
using BLHX.Server.Common.Database;
using BLHX.Server.Game.Managers;

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
        static void BuildShipHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs12002>();

            Logger.c.Log("Id: " + req.Id);
            Logger.c.Log("Cost Type: " + req.Costtype);
            Logger.c.Log("Count: " + req.Count);

            // Id: gacha banner id
            // Count: number of batch builds
            // cost type: 1 wisdom cube + 1500 coin for each gacha i guess?

            // TODO: remove the resources used from player resources

            if (!BuildManager.Instance.BatchBuildShip(req.Id, req.Count))
                Logger.c.Log("Build capacity is full or something went wrong");

            connection.Send(new Sc12003() { 
                BuildInfoes = BuildManager.Instance.ToBuildInfoes() 
            });
        }

        [PacketHandler(Command.Cs12008, SaveDataAfterRun = true)]
        static void BuildShipImmediatelyHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs12008>();
            
            connection.Send(new Sc12009() { PosLists = req.PosLists });
        }

        [PacketHandler(Command.Cs12043, SaveDataAfterRun = true)]
        static void GetShipHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs12043>();
            
            // pos: position in build, Tid: banner id? 
            connection.Send(new Sc12044() {
                infoLists = BuildManager.Instance.ToInfoLists()
            });
        }

        [PacketHandler(Command.Cs12025, SaveDataAfterRun = true)]
        static void GetShipAfterHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs12025>();

            connection.Send(new Sc12026() {
                ShipLists = BuildManager.Instance.GetBuildResults(req.PosLists, connection.player.Uid)
            });
            
        }

        [PacketHandler(Command.Cs12045, SaveDataAfterRun = true)]
        static void GetShipConfirmHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs12045>();

            BuildManager.Instance.ClearBuilds();

            connection.Send(new Sc12046());
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
            Logger.c.Log("NotifyBuildShipData");

            connection.Send(new Sc12024() {
                WorklistCount = 1,
                WorklistLists = BuildManager.Instance.ToBuildInfoes(),
                DrawCount1 = 1,
                DrawCount10 = 1,
                ExchangeCount = 1,
            });
        }
    }
}
