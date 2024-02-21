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

        public static void NotifyShipSkinData(this Connection connection)
        {
            connection.Send(new Sc12201());
        }

        public static void NotifyFleetData(this Connection connection)
        {
            if (connection.player is not null)
            {
                connection.Send(new Sc12101()
                {
                    GroupLists = [
                        new Groupinfo() { Id = 1, ShipLists = [1, 2] },
                        new Groupinfo() { Id = 2 },
                        new Groupinfo() { Id = 11 },
                        new Groupinfo() { Id = 12 }
                    ]
                });
            }
        }
    }
}
