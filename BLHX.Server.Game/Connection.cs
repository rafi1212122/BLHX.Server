using BHXY.Server.Common.Proto.p10;
using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Utils;
using ProtoBuf;
using System.Buffers.Binary;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;

namespace BLHX.Server.Game
{
    public class Connection
    {
        readonly TcpClient tcpClient;
        readonly Logger c;
        readonly CancellationTokenSource cts = new();
        readonly Task loopTask;
        ushort packetIdx = 0;
        public static JsonSerializerOptions jsonSerializerOptions = new() { IncludeFields = true };
        private ushort NextPacketIdx => packetIdx++;
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
                        if (len - readLen < Packet.HEADER_SIZE + Packet.LENGTH_SIZE)
                            break;

                        var packet = new Packet(buf[readLen..]);
                        if (packet.command == Command.Cs10800)
                        {
                            var dec = packet.Decode<Cs10800>();
                            c.Debug(JsonSerializer.Serialize(dec, jsonSerializerOptions));
                        }
                        readLen += packet.length + Packet.LENGTH_SIZE;
                    }

                    pos += len - readLen;
                    if (pos > 0)
                        Array.Copy(buf, readLen, buf, 0, pos);
                }
                catch (Exception ex)
                {
                    c.Error($"An error occured while reading packets {ex}");
                }
            }
        }

        public void Send<T>(T packet) where T : IExtensible
        {
            Command command = Enum.Parse<Command>(packet.GetType().Name);
            var ns = tcpClient.GetStream();

            using var ms = new MemoryStream();
            Serializer.Serialize(ms, packet);

            byte[] sendBuf = GC.AllocateUninitializedArray<byte>(Packet.LENGTH_SIZE + Packet.HEADER_SIZE + (int)ms.Length);
            BinaryPrimitives.WriteUInt16BigEndian(sendBuf, (ushort)(ms.Length + Packet.HEADER_SIZE));
            sendBuf[Packet.LENGTH_SIZE] = 0;
            BinaryPrimitives.WriteUInt16BigEndian(sendBuf.AsSpan(Packet.LENGTH_SIZE + 1), (ushort)command);
            BinaryPrimitives.WriteUInt16BigEndian(sendBuf.AsSpan(Packet.HEADER_SIZE), NextPacketIdx);
            ms.ToArray().CopyTo(sendBuf.AsSpan(Packet.LENGTH_SIZE + Packet.HEADER_SIZE));

            c.Debug(BitConverter.ToString(sendBuf).Replace("-", ""));
            ns.Write(sendBuf);
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
