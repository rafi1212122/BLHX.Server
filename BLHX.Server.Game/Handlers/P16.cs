using BLHX.Server.Common.Proto.p16;

namespace BLHX.Server.Game.Handlers
{
    internal static class P16
    {
    }

    static class P16ConnectionNotifyExtensions
    {
        public static void NotifyShopMonthData(this Connection connection)
        {
            connection.Send(new Sc16200() { Month = (uint)DateTime.Now.Month });
        }
    }
}
