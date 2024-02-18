using BLHX.Server.Common.Proto;
using ProtoBuf;
using System.Buffers.Binary;

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
}
