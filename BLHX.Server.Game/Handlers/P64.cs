using BLHX.Server.Common.Proto.p64;

namespace BLHX.Server.Game.Handlers
{
    static class P64ConnectionNotifyExtensions
    {
        public static void NotifyTechSetLists(this Connection connection)
        {
            connection.Send(new Sc64000());
        }
    }
}
