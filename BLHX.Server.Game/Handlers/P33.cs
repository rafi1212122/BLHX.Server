using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p33;

namespace BLHX.Server.Game.Handlers {
    internal class P33 {
        [PacketHandler(Command.Cs33000, SaveDataAfterRun = true)]
        static void ReqWorldCheckHandler(Connection connection, Packet packet) {
            var req = packet.Decode<Cs33000>();
            
            connection.Send(new Sc33001() { 
                IsWorldOpen = 0,
            });
        }
        
    }
    static class P33ConnectionNotifyExtensions {
        public static void NotifyWorldData(this Connection connection) {
            connection.Send(new Sc33114() {
                IsWorldOpen = 1
            });
        }
    }
}
