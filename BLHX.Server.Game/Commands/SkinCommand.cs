using BLHX.Server.Common.Data;
using BLHX.Server.Common.Database;
using BLHX.Server.Common.Proto.common;
using BLHX.Server.Game.Handlers;

namespace BLHX.Server.Game.Commands
{
    [CommandHandler("skin", "Unlock skins of a character or all characters", "skin unlock=all")]
    public class SkinCommand : Command
    {
        [Argument("unlock")]
        public string? Unlock { get; set; }

        public override void Execute(Dictionary<string, string> args, Connection connection)
        {
            base.Execute(args);

            if (Unlock is not null)
            {
                if (Unlock.Equals("all", StringComparison.CurrentCultureIgnoreCase))
                {
                    connection.player.ShipSkins = connection.player.Ships.SelectMany(x =>
                    {
                        ShipDataTemplate? template = Data.ShipDataTemplate.FirstOrDefault(y => y.Value.Id == x.TemplateId).Value;
                        return Data.ShipSkinTemplate.Where(x => x.Value.ShipGroup == template.GroupType).Select(x => new Idtimeinfo() { Id = x.Value.Id });
                    }).DistinctBy(x => x.Id).ToList();
                }
                else
                {
                    var shipId = Parse(Unlock, uint.MinValue);
                    if (connection.player.Ships.Any(x => x.TemplateId == shipId))
                    {
                        ShipDataTemplate? template = Data.ShipDataTemplate.FirstOrDefault(y => y.Value.Id == shipId).Value;
                        connection.player.ShipSkins.AddRange(Data.ShipSkinTemplate.Where(x => x.Value.ShipGroup == template.GroupType).Select(x => new Idtimeinfo() { Id = x.Value.Id }));
                    }
                    else
                    {
                        if (!Data.ShipSkinTemplate.Any(x => x.Value.ShipGroup == shipId))
                        {
                            connection.SendSystemMsg($"You don't own a ship with a template/group id of {shipId}");
                            return;
                        }

                        connection.player.ShipSkins.AddRange(Data.ShipSkinTemplate.Where(x => x.Value.ShipGroup == shipId).Select(x => new Idtimeinfo() { Id = x.Value.Id }));
                    }
                }
                connection.NotifyShipSkinData();
            }

            base.NotifySuccess(connection);
            DBManager.PlayerContext.Save();
        }
    }
}
