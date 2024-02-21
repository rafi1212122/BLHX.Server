using BLHX.Server.Common.Proto.p50;

namespace BLHX.Server.Game.Managers
{
    public class ChatManager
    {
        List<MsgInfo> messages = [];

        public void SendChat(MsgInfo msgInfo)
        {
            msgInfo.Timestamp = (uint)DateTimeOffset.Now.ToUnixTimeSeconds();

            messages.Add(msgInfo);
            BroadcastChat(msgInfo);
        }

        void BroadcastChat(MsgInfo msgInfo)
        {
            var ntf = new Sc50101()
            {
                Content = msgInfo.Content,
                Player = msgInfo.Player,
                Type = 1
            };

            foreach (var conn in GameServer.connections.Values)
                conn.Send(ntf);
        }
    }
}
