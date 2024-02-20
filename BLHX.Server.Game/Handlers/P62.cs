using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p62;

namespace BLHX.Server.Game.Handlers
{
    internal static class P62
    {
        [PacketHandler(Command.Cs62100)]
        static void GuildPublicUserDataHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc62101());
        }
    }
}
