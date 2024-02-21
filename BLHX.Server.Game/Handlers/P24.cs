using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p24;

namespace BLHX.Server.Game.Handlers
{
    internal static class P24
    {
        [PacketHandler(Command.Cs24020)]
        static void LimitChallengeHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc24021()
            {
                Awards = [
                    new() { Key = 10025, Value = 0 },
                    new() { Key = 10026, Value = 0 },
                    new() { Key = 10027, Value = 0 }
                ]
            });
        }
    }
}
