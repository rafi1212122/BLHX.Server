using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p40;

namespace BLHX.Server.Game.Handlers
{
    internal static class P40
    {
        [PacketHandler(Command.Cs40001)]
        static void BeginStageHandler(Connection connection, Packet packet)
        {
            // TODO: Check the importance of the request data and calculate oil and gold cost pls
            connection.Send(new Sc40002());
        }

        [PacketHandler(Command.Cs40003)]
        static void FinishStageHandler(Connection connection, Packet packet)
        {
            // TODO: Calculate rewarded EXP and drop rewards
            var req = packet.Decode<Cs40003>();

            connection.Send(new Sc40004()
            {
                ShipExpLists = req.Statistics.Select(x => new ShipExp() { ShipId = x.ShipId, Intimacy = 10000 }).ToList(),
                Mvp = req.Statistics.First().ShipId
            });
        }
    }
}
