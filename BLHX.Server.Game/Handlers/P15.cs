using BLHX.Server.Common.Proto.p15;

namespace BLHX.Server.Game.Handlers
{
    internal static class P15
    {
    }

    static class P15ConnectionNotifyExtensions
    {
        public static void NotifyBagData(this Connection connection)
        {
            connection.Send(new Sc15001()
            {
                ItemLists = [
                    new Iteminfo() { Id = 20001, Count = 5 },
                    new Iteminfo() { Id = 15003, Count = 10 },
                    new Iteminfo() { Id = 50002, Count = 10 },
                    new Iteminfo() { Id = 50001, Count = 10 }
                ]
            });
        }
    }
}
