using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Utils;
using ProtoBuf;
using System.Buffers.Binary;
using System.Reflection;

namespace BLHX.Server.Game
{
    readonly struct Packet
    {
        public const int LENGTH_SIZE = 2;
        public const int HEADER_SIZE = 5;
        public readonly ushort length;
        public readonly byte flag;
        public readonly Command command;
        public readonly ushort id;
        public readonly byte[] bytes;

        public Packet(byte[] recv)
        {
            length = BinaryPrimitives.ReadUInt16BigEndian(recv);
            flag = recv[LENGTH_SIZE];
            command = (Command)BinaryPrimitives.ReadUInt16BigEndian(recv.AsSpan(LENGTH_SIZE + 1));
            id = BinaryPrimitives.ReadUInt16BigEndian(recv.AsSpan(HEADER_SIZE));
            bytes = GC.AllocateUninitializedArray<byte>(length - HEADER_SIZE);
            Array.Copy(recv, HEADER_SIZE + LENGTH_SIZE, bytes, 0, length - HEADER_SIZE);
        }

        public T Decode<T>() where T : IExtensible => Serializer.Deserialize<T>(bytes.AsSpan());
    }

    static class PacketFactory
    {
        static readonly Logger c = new(nameof(PacketFactory), ConsoleColor.DarkGreen);
        static readonly Dictionary<Command, PacketHandlerDelegate> handlers = [];

        static PacketFactory()
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

                handlers.Add(attr.command, (PacketHandlerDelegate)Delegate.CreateDelegate(typeof(PacketHandlerDelegate), method));
                c.Log($"Loaded {method.Name} for {attr.command}");
            }
            c.Log($"{handlers.Count} packet handlers loaded!");
        }

        public static PacketHandlerDelegate? GetPacketHandler(Command command)
        {
            handlers.TryGetValue(command, out var handler);
            return handler;
        }
    }

    delegate void PacketHandlerDelegate(Connection connection, Packet packet);

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    class PacketHandlerAttribute(Command command) : Attribute
    {
        public Command command = command;
    }
}
