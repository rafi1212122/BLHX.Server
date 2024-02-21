using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p60;

namespace BLHX.Server.Game.Handlers
{
    internal static class P60
    {
        [PacketHandler(Command.Cs60033)]
        static void GetGuildShopHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc60034());
        }
        
        [PacketHandler(Command.Cs60037)]
        static void GuildInfoHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc60000()
            {
                Guild = new()
                {
                    DonateTasks = [1],
                    TechIds = [8, 0, 18, 6, 8, 0, 16, 0, 24, 0, 24, 0, 40, 0, 48, 0, 56, 0, 64, 0],
                    BenefitTime = 1,
                    WeeklyTaskFlag = 1
                }
            });
        }

        [PacketHandler(Command.Cs60102)]
        static void GuildUserInfoHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc60103()
            {
                UserInfo = new()
                {
                    DonateTasks = [1, 20, 4]
                }
            });
        }
    }
}
