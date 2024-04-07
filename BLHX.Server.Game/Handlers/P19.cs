using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p19;
using BLHX.Server.Common.Utils;

namespace BLHX.Server.Game.Handlers {
    internal static class P19 {
        [PacketHandler(Command.Cs19002, SaveDataAfterRun = true)]
        static void AddShipHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs19002>();

            connection.Send(new Sc19003() {});
            connection.Send(new Sc19003() {});
        }

        [PacketHandler(Command.Cs19004, SaveDataAfterRun = true)]
        static void ShipExitHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs19004>();

            connection.Send(new Sc19005() { });
        }

        [PacketHandler(Command.Cs19103, SaveDataAfterRun = true)]
        static void GetOSSArgsHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs19103>();

            connection.Send(new Sc19104() {
                AccessId = "1",
                AccessSecret = "1",
                ExpireTime = (uint)new DateTimeOffset(DateTime.Now.AddDays(31)).ToUnixTimeSeconds(),
                SecurityToken = "3874839" // idk what this is so i put a random as token
            });
        }
    }

    static class P19ConnectionNotifyExtensions {
        public static void NotifyDormData(this Connection connection) {
            connection.Send(new Sc19001() {
                Lv = 1,
                FloorNum = 1,
                ExpPos = 2,
                LoadTime = (uint)DateTimeOffset.Now.ToUnixTimeSeconds()
            });
        }
    }
}
