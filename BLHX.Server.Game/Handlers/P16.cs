using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p16;
using BLHX.Server.Common.Utils;

namespace BLHX.Server.Game.Handlers {
    internal static class P16 {
        [PacketHandler(Command.Cs16001, SaveDataAfterRun = true)]
        static void DormTrainShoppingHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs16001>();

            Logger.c.Log("Id: " + req.Id);
            Logger.c.Log("Number: " + req.Number);

            connection.Send(new Sc16002() { });
        }

        [PacketHandler(Command.Cs16104)]
        static void GetChargeListHandler(Connection connection, Packet packet) {
            connection.Send(new Sc16105());
        }

        [PacketHandler(Command.Cs16106)]
        static void GetExchangeItemHandler(Connection connection, Packet packet) {
            connection.Send(new Sc16107());
        }
    }

    static class P16ConnectionNotifyExtensions {
        public static void NotifyShopMonthData(this Connection connection) {
            connection.Send(new Sc16200() { Month = (uint)DateTime.Now.Month });
        }
    }
}
