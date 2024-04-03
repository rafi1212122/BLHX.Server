using BLHX.Server.Common.Data;
using BLHX.Server.Common.Database;
using BLHX.Server.Common.Proto.common;
using BLHX.Server.Common.Utils;
using BLHX.Server.Game.Handlers;

namespace BLHX.Server.Game.Commands {
    [CommandHandler("ship", "Unlock a character or all characters", "ship unlock=all")]
    public class ShipCommand : Command {
        [Argument("unlock")]
        public string? Unlock { get; set; }

        public override void Execute(Dictionary<string, string> args, Connection connection) {
            base.Execute(args);

            if (Unlock is null) {
                Logger.c.Log($"Usage: /ship unlock=<all|clear|shipId>");
                return;
            }

            if (Unlock.Equals("all", StringComparison.CurrentCultureIgnoreCase)) {
                int amount = 500; // not sure why but if you add more than this amount the client crashes
                List<int> all_ship_ids = Data.ShipDataTemplate.Where(x => x.Value.Star == x.Value.StarMax && x.Value.Star >= 5).ToDictionary().Keys.ToList();
                List<PlayerShip> all_ships = all_ship_ids.Select(ship_id => CreateShipFromId((uint)ship_id, connection.player.Uid)).Take(amount).ToList();

                all_ships.AddRange(GetDefaultShips(connection.player.Ships)); // add the defaults
                connection.player.Ships = all_ships;
                connection.SendSystemMsg($"Added {amount} ships!");

            } else if (Unlock.Equals("clear", StringComparison.CurrentCultureIgnoreCase)) {
                connection.player.Ships = GetDefaultShips(connection.player.Ships);
                connection.SendSystemMsg($"Cleared all ships!");

            } else if (uint.TryParse(Unlock, out uint shipId)) {
                connection.player.AddShip(shipId);

            } else {
                connection.SendSystemMsg($"Invalid Ship Id: {shipId}");
                return;
            }

            DBManager.PlayerContext.Save();
            connection.NotifyShipData();
            base.NotifySuccess(connection);
        }

        public static PlayerShip CreateShipFromId(uint shipId, uint playerUid) {
            if (!Data.ShipDataTemplate.TryGetValue((int)shipId, out var shipTemplate))
                throw new InvalidDataException($"Ship template {shipId} not found!");

            var ship = new PlayerShip() {
                TemplateId = shipId,
                Level = 1,
                EquipInfoLists = [
                    new EquipskinInfo() { Id = shipTemplate.EquipId1 },
                    new EquipskinInfo() { Id = shipTemplate.EquipId2 },
                    new EquipskinInfo() { Id = shipTemplate.EquipId3 },
                    new EquipskinInfo(),
                    new EquipskinInfo(),
                ],
                Energy = shipTemplate.Energy,
                SkillIdLists = shipTemplate.BuffList.Select(x => new Shipskill() { SkillId = x, SkillLv = 1 }).ToList(),
                Intimacy = 5000,

                PlayerUid = playerUid
            };

            return ship;
        }

        public static ICollection<PlayerShip> GetDefaultShips(ICollection<PlayerShip> playerShips) {
            return playerShips.Where(ship => ship.TemplateId == 106011 || ship.TemplateId == 101171).ToList();
        }
    }
}
