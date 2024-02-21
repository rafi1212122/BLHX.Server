using BLHX.Server.Common.Proto.p63;

namespace BLHX.Server.Game.Handlers
{
    static class P63ConnectionNotifyExtensions
    {
        public static void NotifyTechnologyData(this Connection connection)
        {
            connection.Send(new Sc63000());
        }
        
        public static void NotifyBlueprintData(this Connection connection)
        {
            connection.Send(new Sc63100());
        }
    }
}
