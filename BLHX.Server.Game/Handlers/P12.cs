using BLHX.Server.Common.Proto.p12;

namespace BLHX.Server.Game.Handlers
{
    internal static class P12
    {
    }

    static class P12ConnectionNotifyExtensions
    {
        public static void NotifyShipData(this Connection connection)
        {
            if (connection.player is not null)
            {
                connection.Send(new Sc12001()
                {
                    Shiplists = connection.player.Ships.Select(x => x.ToProto()).ToList()
                });
            }
        }
    }
}
