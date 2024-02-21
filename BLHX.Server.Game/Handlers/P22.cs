using BLHX.Server.Common.Proto.p22;

namespace BLHX.Server.Game.Handlers
{
    internal static class P22
    {
    }

    static class P22ConnectionNotifyExtensions
    {
        public static void NotifyNavalAcademy(this Connection connection)
        {
            connection.Send(new Sc22001()
            {
                OilWellLevel = 1,
                GoldWellLevel = 1,
                ClassLv = 1,
                Class = new(),
                SkillClassNum = 2
            });
        }
    }
}
