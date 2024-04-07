using BLHX.Server.Common.Proto.p15;
using BLHX.Server.Common.Data;
using BLHX.Server.Common.Utils;
using BLHX.Server.Common.Proto;

namespace BLHX.Server.Game.Handlers {
    internal static class P15 {
        [PacketHandler(Command.Cs15002, SaveDataAfterRun = true)]
        static void UseFudaiItemHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs15002>();

            Logger.c.Log("Arg: ");

            foreach (var arg in req.Args)
                Logger.c.Log(arg + "");

            Logger.c.Log(req.Count + "");
            Logger.c.Log(req.Id + "");

            connection.Send(new Sc15003() {
                DropLists = [],
            });
        }
    }

    static class P15ConnectionNotifyExtensions {

        public static void NotifyBagData(this Connection connection) {
            //List<int> AllItemsKeys = Data.ItemDataStatistics.Where(data =>  data.Value.Type == 2 && data.Value.Rarity >= 6).ToDictionary().Keys.ToList();
            List<int> AllItemsKeys = Data.ItemDataStatistics.ToDictionary().Keys.ToList();
            List<Iteminfo> ItemLists = AllItemsKeys.Select(item_id => new Iteminfo { Id = (uint)item_id, Count = 3954783433 }).ToList();

            connection.Send(new Sc15001() { ItemLists = ItemLists });

            //connection.Send(new Sc15001() {
            //    ItemLists = [
            //        new Iteminfo() { Id = 20001, Count = 8394785 },
            //        new Iteminfo() { Id = 15003, Count = 10 },
            //        new Iteminfo() { Id = 50002, Count = 10 },
            //        new Iteminfo() { Id = 50001, Count = 10 }
            //    ]
            //});

        }
    }
}
