using BLHX.Server.Common.Data;
using BLHX.Server.Common.Utils;
using BLHX.Server.Game;
using BLHX.Server.Sdk;
using System.Net.NetworkInformation;
using System.Reflection;

namespace BLHX.Server;

internal class Program
{
    static void Main(string[] args)
    {
        Logger.c.Log($"Version {Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyInformationalVersionAttribute>()?.InformationalVersion}");
        Logger.c.Log("Starting...");

        Config.Load();
        if (Config.Instance.Address == "127.0.0.1")
        {
            Config.Instance.Address = NetworkInterface.GetAllNetworkInterfaces().Where(i => i.NetworkInterfaceType != NetworkInterfaceType.Loopback && i.OperationalStatus == OperationalStatus.Up).First().GetIPProperties().UnicastAddresses.Where(a => a.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).First().Address.ToString();
            Config.Save();
        }

        Data.Load();

        Task.Run(GameServer.Start);
        SDKServer.Main(args);
        Task.Run(InputSystem.Start).Wait();
    }
}
