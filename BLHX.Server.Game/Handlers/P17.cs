using BLHX.Server.Common.Data;
using BLHX.Server.Common.Proto.p17;

namespace BLHX.Server.Game.Handlers
{
    internal class P17
    {
    }

    static class P17ConnectionNotifyExtensions
    {
        public static void NotifyStatisticsInit(this Connection connection)
        {
            if (connection.player is not null)
            {
                connection.Send(new Sc17001()
                {
                    ShipInfoLists = connection.player.Ships.OrderByDescending(x => x.Level).DistinctBy(x => x.TemplateId).Select(x =>
                    {
                        var template = Data.ShipDataTemplate[(int)x.TemplateId];

                        return new ShipStatisticsInfo()
                        {
                            Id = template.GroupType,
                            Star = template.Star,
                            LvMax = x.Level,
                            IntimacyMax = x.Intimacy
                        };
                    }).ToList()
                });
            }
        }
    }
}
