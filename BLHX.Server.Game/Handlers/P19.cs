using BLHX.Server.Common.Proto.p19;

namespace BLHX.Server.Game.Handlers
{
    internal static class P19
    {
    }

    static class P19ConnectionNotifyExtensions
    {
        public static void NotifyDormData(this Connection connection)
        {
            connection.Send(new Sc19001()
            {
                Lv = 1,
                FloorNum = 1,
                ExpPos = 2,
                LoadTime = (uint)DateTimeOffset.Now.ToUnixTimeSeconds()
            });
        }
    }
}
