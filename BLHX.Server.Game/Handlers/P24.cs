using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p24;

namespace BLHX.Server.Game.Handlers
{
    internal static class P24
    {
        [PacketHandler(Command.Cs24020)]
        static void LimitChallengeHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc24021());
        }
    }
}
