using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p26;

namespace BLHX.Server.Game.Handlers
{
    internal static class P26
    {
        [PacketHandler(Command.Cs26101)]
        static void MiniGameHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc26102());
        }
    }
}
