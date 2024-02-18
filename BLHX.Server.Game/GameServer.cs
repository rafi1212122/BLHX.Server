using System.Net;
using System.Net.Sockets;
using BLHX.Server.Common.Utils;

namespace BLHX.Server.Game
{
    public static class GameServer
    {
        static readonly TcpListener listener;
        public static readonly Dictionary<IPEndPoint, Connection> connections = new();
        public static readonly Logger c = new(nameof(GameServer), ConsoleColor.Magenta);
        public static IPEndPoint EndPoint { get; }

        static GameServer()
        {
            // Preload
            System.Runtime.CompilerServices.RuntimeHelpers.RunClassConstructor(typeof(PacketFactory).TypeHandle);

            EndPoint = new(IPAddress.Any, 20000);
            listener = new TcpListener(EndPoint);
        }

        public static async Task Start()
        {
            listener.Start();
            c.Log($"{nameof(GameServer)} started on {EndPoint}");

            while (true)
            {
                try
                {
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    if (client.Client.RemoteEndPoint is not null and IPEndPoint)
                    {
                        if (connections.ContainsKey((IPEndPoint)client.Client.RemoteEndPoint))
                            connections[(IPEndPoint)client.Client.RemoteEndPoint].EndProtocol();

                        connections[(IPEndPoint)client.Client.RemoteEndPoint] = new Connection(client);
                        continue;
                    }
                    client.Dispose();
                }
                catch (Exception ex)
                {
                    c.Error($"{nameof(GameServer)} listener error {ex}");
                }
            }
        }
    }
}
