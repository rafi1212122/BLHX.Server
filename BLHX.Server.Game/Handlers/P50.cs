using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p50;

namespace BLHX.Server.Game.Handlers
{
    internal static class P50
    {
        [PacketHandler(Command.Cs50014)]
        static void SearchFriendCommandHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc50015());
        }
        
        [PacketHandler(Command.Cs50016)]
        static void GetBlacklistHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc50017());
        }
    }
}
