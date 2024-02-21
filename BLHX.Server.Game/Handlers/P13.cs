using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p13;

namespace BLHX.Server.Game.Handlers
{
    internal static class P13
    {
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
            connection.Send(new Sc13001() {  ReactChapter = new() });
        }
    }
}
