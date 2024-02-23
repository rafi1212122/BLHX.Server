using BLHX.Server.Common.Proto.p14;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLHX.Server.Game.Handlers
{
    internal class P14
    {
    }

    static class P14ConnectionNotifyExtensions
    {
        public static void NotifyEquipList(this Connection connection)
        {
            connection.Send(new Sc14001()
            {
                SpweaponBagSize = 150
            });
        }

        public static void NotifyEquipSkinList(this Connection connection)
        {
            connection.Send(new Sc14101());
        }
    }
}
