using BLHX.Server.Common.Database;
using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Utils;
using BLHX.Server.Game.Handlers;
using ProtoBuf;
using System.Buffers.Binary;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace BLHX.Server.Game
{
    public class Connection
    {
        public const uint Monday0oclockTimestamp = 1606114800;
        public readonly Logger c;
        public Account account = null!;
        public Player player = null!;
        readonly TcpClient tcpClient;
        readonly CancellationTokenSource cts = new();
        readonly Task loopTask;
        ushort packetIdx = 0;
        private ushort NextPacketIdx => packetIdx;
        public IPEndPoint EndPoint => (IPEndPoint)tcpClient.Client.RemoteEndPoint!;

        public Connection(TcpClient tcpClient)
        {
            this.tcpClient = tcpClient;
            GameServer.c.Log($"{EndPoint} connected");
            c = new(EndPoint.ToString());
            loopTask = Task.Run(ClientLoop, cts.Token);
        }

        private async Task ClientLoop()
        {
            var ns = tcpClient.GetStream();
            var buf = GC.AllocateUninitializedArray<byte>(ushort.MaxValue);
            // TODO: pos isn't actually doing anything
            var pos = 0;

            while (!cts.Token.IsCancellationRequested)
            {
                try
                {
                    int len = await ns.ReadAsync(buf.AsMemory(pos, buf.Length - pos), cts.Token);

                    len += pos;
                    if (len < 1)
                        continue;

                    int readLen = 0;
                    while (readLen < len)
                    {
                        if (buf.AsSpan(0, 22).SequenceEqual(Encoding.UTF8.GetBytes("GET /?cmd=load_server?")))
                        {
                            string svrList = @"[{""id"":1,""name"":""BLHX.Server"",""state"":0,""flag"":0,""sort"":0}]";
                            SendHttpResponse(svrList, "application/json");
                            readLen = len;
                            EndProtocol();
                            break;
                        }

                        if (len - readLen < Packet.HEADER_SIZE + Packet.LENGTH_SIZE)
                            break;

                        var packet = new Packet(buf[readLen..]);
                        c.Log(packet.command.ToString());

                        var handler = PacketFactory.GetPacketHandler(packet.command);
                        if (handler is not null)
                        {
                            handler(this, packet);
                            packetIdx++;
                        }
                        else
                        {
                            c.Warn($"{packet.command} unhandled!"
#if DEBUG
                                , Enum.IsDefined(packet.command) ? BitConverter.ToString(packet.bytes).Replace("-", "") : BitConverter.ToString(buf[readLen..]).Replace("-", "")
#endif
                            );
                        }

                        readLen += packet.length + Packet.LENGTH_SIZE;
                    }

                    if (len == readLen)
                        pos = 0;
                }
                catch (Exception ex)
                {
                    c.Error($"An error occured while reading packets {ex}");
                    break;
                }
            }

            EndProtocol();
        }

        public void Send<T>(T packet) where T : IExtensible
        {
            Command command = Enum.Parse<Command>(packet.GetType().Name);
            c.Log(command.ToString());
            var ns = tcpClient.GetStream();

            using var ms = new MemoryStream();
            Serializer.Serialize(ms, packet);

            byte[] sendBuf = GC.AllocateUninitializedArray<byte>(Packet.LENGTH_SIZE + Packet.HEADER_SIZE + (int)ms.Length);
            BinaryPrimitives.WriteUInt16BigEndian(sendBuf, (ushort)(ms.Length + Packet.HEADER_SIZE));
            sendBuf[Packet.LENGTH_SIZE] = 0;
            BinaryPrimitives.WriteUInt16BigEndian(sendBuf.AsSpan(Packet.LENGTH_SIZE + 1), (ushort)command);
            BinaryPrimitives.WriteUInt16BigEndian(sendBuf.AsSpan(Packet.HEADER_SIZE), NextPacketIdx);
            ms.ToArray().CopyTo(sendBuf.AsSpan(Packet.LENGTH_SIZE + Packet.HEADER_SIZE));

            // c.Debug(BitConverter.ToString(sendBuf).Replace("-", ""));
            ns.Write(sendBuf);
        }

        public void InitClientData()
        {
            this.NotifyPlayerData();
            this.NotifyStatisticsInit();
            this.NotifyShipData();
        }

        public void SendHttpResponse(string rsp, string type = "text/plain")
        {
            tcpClient.GetStream().Write(Encoding.UTF8.GetBytes(
                "HTTP/1.1 200 OK" + Environment.NewLine
                + "Content-Length: " + rsp.Length + Environment.NewLine
                + "Content-Type: " + type + Environment.NewLine
                + Environment.NewLine
                + rsp
                + Environment.NewLine + Environment.NewLine));
        }

        public void EndProtocol()
        {
            cts.Cancel();
            loopTask.GetAwaiter().OnCompleted(loopTask.Dispose);

            GameServer.c.Log($"{EndPoint} disconnected");
            GameServer.connections.Remove(EndPoint);
            tcpClient.Dispose();
        }
    }
}
