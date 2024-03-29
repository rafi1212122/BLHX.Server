﻿using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Utils;
using ProtoBuf;
using System.Buffers.Binary;
using System.Reflection;

namespace BLHX.Server.Game
{
    struct Packet
    {
        public const int LENGTH_SIZE = 2;
        public const int HEADER_SIZE = 5;
        public ushort length;
        public byte flag;
        public Command command;
        public ushort id;
        public byte[] bytes;

        public Packet(byte[] recv)
        {
            length = BinaryPrimitives.ReadUInt16BigEndian(recv);
            flag = recv[LENGTH_SIZE];
            command = (Command)BinaryPrimitives.ReadUInt16BigEndian(recv.AsSpan(LENGTH_SIZE + 1));
            id = BinaryPrimitives.ReadUInt16BigEndian(recv.AsSpan(HEADER_SIZE));
            bytes = GC.AllocateUninitializedArray<byte>(length - HEADER_SIZE);
            Array.Copy(recv, HEADER_SIZE + LENGTH_SIZE, bytes, 0, length - HEADER_SIZE);
        }

        public readonly T Decode<T>() where T : IExtensible => Serializer.Deserialize<T>(bytes.AsSpan());
    }

    static class PacketHandlerFactory
    {
        static readonly Logger c = new(nameof(PacketHandlerFactory), ConsoleColor.DarkGreen);
        static readonly Dictionary<Command, (PacketHandlerDelegate, PacketHandlerAttribute)> handlers = [];

        static PacketHandlerFactory()
        {
            LoadPacketHandlers();
        }

        private static void LoadPacketHandlers()
        {
            foreach (var method in Assembly.GetExecutingAssembly().GetTypes().SelectMany(x => x.GetMethods(BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Where(x => x.GetCustomAttribute<PacketHandlerAttribute>() is not null)))
            {
                var attr = method.GetCustomAttribute<PacketHandlerAttribute>()!;
                if (handlers.ContainsKey(attr.command))
                    continue;

                handlers.Add(attr.command, ((PacketHandlerDelegate)Delegate.CreateDelegate(typeof(PacketHandlerDelegate), method), attr));
                c.Log($"Loaded {method.Name} for {attr.command}");
            }
            c.Log($"{handlers.Count} packet handlers loaded!");
        }

        public static (PacketHandlerDelegate?, PacketHandlerAttribute?) GetPacketHandler(Command command)
        {
            handlers.TryGetValue(command, out var handler);
            return ((PacketHandlerDelegate, PacketHandlerAttribute)?)handler ?? (null, null)!;
        }
    }

    delegate void PacketHandlerDelegate(Connection connection, Packet packet);


    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    class PacketHandlerAttribute : Attribute
    {
        public Command command;

        /// <summary>
        /// Some packets that sent by the client doensn't need a reply.
        /// It's important for such packet doesnt increment the packet id counter, example for such packet is Cs12299 & Cs50102
        /// </summary>
        public bool IsNotifyHandler { get; init; }
        public bool SaveDataAfterRun { get; init; }

        public PacketHandlerAttribute(Command command)
        {
            this.command = command;
        }
    }
}
