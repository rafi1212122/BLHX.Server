using BLHX.Server.Common.Proto;
using BLHX.Server.Common.Proto.p22;

namespace BLHX.Server.Game.Handlers
{
    internal static class P22
    {
        [PacketHandler(Command.Cs22101)]
        static void GetShopStreetHandler(Connection connection, Packet packet)
        {
            connection.Send(new Sc22102()
            {
                Street = new()
                {
                    Lv = 1
                }
            });
        }
    }

    static class P22ConnectionNotifyExtensions
    {
        public static void NotifyNavalAcademy(this Connection connection)
        {
            connection.Send(new Sc22001()
            {
                OilWellLevel = connection.player.ResourceFields.FirstOrDefault(x => x.Type == Common.Database.ResourceFieldType.Oil)?.Level ?? 1,
                GoldWellLevel = connection.player.ResourceFields.FirstOrDefault(x => x.Type == Common.Database.ResourceFieldType.Gold)?.Level ?? 1,
                ClassLv = 1,
                Class = new(),
                SkillClassNum = 2
            });
        }
    }
}
