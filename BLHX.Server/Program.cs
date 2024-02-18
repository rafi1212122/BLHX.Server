using BLHX.Server.Common.Utils;
using BLHX.Server.Game;

namespace BLHX.Server
{
    internal class Program
    {
        static void Main()
        {
            Logger.c.Log("Starting...");
            Task.Run(GameServer.Start).Wait();
        }
    }
}
