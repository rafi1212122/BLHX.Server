using BLHX.Server.Common.Utils;
using BLHX.Server.Game;

namespace BLHX.Server;

internal class Program
{
    static void Main()
    {
        Logger.c.Log("Starting...");

        Config.Load();

        Task.Run(GameServer.Start);
        Task.Run(InputSystem.Start).Wait();
    }
}
