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
        
        [PacketHandler(Command.Cs50102, IsNotifyHandler = true)]
        static void SendMsgHandler(Connection connection, Packet packet)
        {
            var req = packet.Decode<Cs50102>();

            if (req.Content.StartsWith("/"))
            {
                Commands.CommandHandlerFactory.HandleCommand(req.Content.Substring(1), connection);
                return;
            }

            GameServer.ChatManager.SendChat(new()
            {
                Content = req.Content,
                Player = new()
                {
                    Id = connection.player.Uid,
                    Lv = connection.player.Level,
                    Name = connection.player.Name,
                    Display = connection.player.DisplayInfo
                }
            });
        }
    }

    static class P50ConnectionNotifyExtensions
    {
        public static void SendSystemMsg(this Connection connection, string msg)
        {

            var ntf = new Sc50101()
            {
                Content = msg,
                Player = new()
                {
                    Name = "System",
                    Display = new()
                    {
                        Icon = 107061
                    }
                },
                Type = 1
            };

            connection.Send(ntf);
        }
    }
}
