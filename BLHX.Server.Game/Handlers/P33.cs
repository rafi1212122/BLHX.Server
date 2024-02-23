using BLHX.Server.Common.Proto.p33;

namespace BLHX.Server.Game.Handlers
{
    internal class P33
    {
    }
    static class P33ConnectionNotifyExtensions
    {
        public static void NotifyWorldData(this Connection connection)
        {
            connection.Send(new Sc33114()
            {
                IsWorldOpen = 1
            });
        }
    }
}
