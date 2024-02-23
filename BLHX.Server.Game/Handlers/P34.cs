using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p34;

namespace BLHX.Server.Game.Handlers
{
    internal static class P34
    {
        [PacketHandler(Command.Cs34001)]
        static void GetMetaPTHandler(Connection connection, Packet packet)
        {
            var req = packet.Decode<Cs34001>();
            connection.Send(new Sc34002()
            {
                MetaShipLists = req.GroupIds.Select(x => new MetaShipInfo() { GroupId = x }).ToList()
            });
        }

        [PacketHandler(Command.Cs34501)]
        static void GetWorldBossHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc34502());
        }
    }
}
