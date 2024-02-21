using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p18;

namespace BLHX.Server.Game.Handlers
{
    internal static class P18
    {
        [PacketHandler(Command.Cs18001)]
        static void SeasonInfoHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc18002()
            {
                Rank = 1
            });
        }
        
        [PacketHandler(Command.Cs18100)]
        static void GetMilitaryShopHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc18101());
        }
    }
}
