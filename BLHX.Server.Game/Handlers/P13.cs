using BLHX.Server.Common.Data;
using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p13;

namespace BLHX.Server.Game.Handlers
{
    internal static class P13
    {
        [PacketHandler(Command.Cs13101)]
        static void TrackingHandler(Connection connection, Packet packet)
        {
            var req = packet.Decode<Cs13101>();
            var rsp = new Sc13102();
            if (!Data.ChapterTemplate.TryGetValue((int)req.Id, out var chapterTemplate))
            {
                rsp.Result = 1;
                connection.Send(rsp);
                return;
            }

            // TODO: Populate values, pls make managers
            connection.Send(new Sc13102()
            {
                CurrentChapter = new()
                {
                    Id = req.Id,
                    Time = (uint)(DateTimeOffset.Now.ToUnixTimeSeconds() + chapterTemplate.Time)
                }
            });
        }

        [PacketHandler(Command.Cs13505)]
        static void RemasterInfoRequestHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc13506());
        }
    }

    static class P13ConnectionNotifyExtensions
    {
        public static void NotifyChapterData(this Connection connection)
        {
            connection.Send(new Sc13001() { ReactChapter = new() });
        }
    }
}
