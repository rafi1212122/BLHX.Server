using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using BLHX.Server.Common.Proto;
using PcapDotNet.Core;
using PcapDotNet.Packets;
using ProtoBuf;

namespace BLHX.Server.PcapParser
{
    class PcapParser
    {
        static MemoryStream memoryStream = new MemoryStream();

        static void Main(string[] args)
        {
            // Check command line
            if (args.Length != 1)
            {
                Console.WriteLine("usage: " + Environment.GetCommandLineArgs()[0] + " <filename>");
                return;
            }

            // Create the offline device
            OfflinePacketDevice selectedDevice = new OfflinePacketDevice(args[0]);

            // Open the capture file
            using (PacketCommunicator communicator =
                selectedDevice.Open(65536,                                  // portion of the packet to capture
                                                                            // 65536 guarantees that the whole packet will be captured on all the link layers
                                    PacketDeviceOpenAttributes.Promiscuous, // promiscuous mode
                                    1000))                                  // read timeout
            {
                // Read and dispatch packets until EOF is reached
                communicator.ReceivePackets(0, DispatcherHandler);
            }

            ProcessPackets();
        }

        private static void DispatcherHandler(Packet packet)
        {
            var payload = packet.Ethernet.IpV4.Tcp.Payload;
            if (payload.Length < 1)
                return;

            // print packet timestamp and packet length
            Console.WriteLine(packet.Timestamp.ToString("yyyy-MM-dd hh:mm:ss.fff") + " length:" + payload.Length);
            memoryStream.Write(payload.ToArray(), 0, payload.Length);
        }

        private static void ProcessPackets()
        {
            List<BLHXPacket> packets = new List<BLHXPacket>();

            byte[] msBytes = memoryStream.ToArray();
            int readLen = 0;
            while (readLen < msBytes.Length)
            {
                var gamePacket = new BLHXPacket(msBytes.AsSpan(readLen).ToArray());
                readLen += gamePacket.length + BLHXPacket.LENGTH_SIZE;
                packets.Add(gamePacket);

                try
                {
                    var protoClass = Assembly.GetExecutingAssembly().GetType($"BLHX.Server.Common.Proto.p{gamePacket.command.ToCategory()}.{gamePacket.command}");
                    using (var ms = new MemoryStream(gamePacket.bytes))
                    {
                        gamePacket.body = Serializer.Deserialize(protoClass, ms);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine($"{gamePacket.command} failed to deserialize, {BitConverter.ToString(gamePacket.bytes).Replace("-", "")}");
                }
            }

            Console.WriteLine($"Got {packets.Count} packet(s)");
            File.WriteAllText("packets.json", JsonConvert.SerializeObject(packets));
        }
    }

    static class CommandExtensions
    {
        public static string ToCategory(this Command command)
        {
            string cmdStr = ((ushort)command).ToString();
            return cmdStr.Substring(0, Math.Min(2, cmdStr.Length)); ;
        }
    }

    class BLHXPacket
    {
        public const int LENGTH_SIZE = 2;
        public const int HEADER_SIZE = 5;
        public readonly ushort length;
        public readonly byte flag;
        public readonly Command command;
        public readonly ushort id;
        public readonly byte[] bytes;
        public object body;

        public BLHXPacket(byte[] recv)
        {
            length = BinaryPrimitives.ReadUInt16BigEndian(recv);
            flag = recv[LENGTH_SIZE];
            command = (Command)BinaryPrimitives.ReadUInt16BigEndian(recv.AsSpan(LENGTH_SIZE + 1));
            id = BinaryPrimitives.ReadUInt16BigEndian(recv.AsSpan(HEADER_SIZE));
            bytes = new byte[length - HEADER_SIZE];
            Array.Copy(recv, HEADER_SIZE + LENGTH_SIZE, bytes, 0, length - HEADER_SIZE);
        }

        public T Decode<T>() where T : IExtensible => Serializer.Deserialize<T>(bytes.AsSpan());
    }
}