using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLHX.Server.Common.Utils
{
    public static class TypeExtensions
    {
        static readonly HashSet<Type> numericTypes =
        [
            typeof(byte),
            typeof(sbyte),
            typeof(short),
            typeof(ushort),
            typeof(int),
            typeof(uint),
            typeof(float),
            typeof(long),
            typeof(ulong),
            typeof(decimal)
        ];

        public static bool IsTypeNumeric(this Type type)
        {
            return numericTypes.Contains(type);
        }
    }
}
