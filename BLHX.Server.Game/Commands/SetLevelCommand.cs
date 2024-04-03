using BLHX.Server.Common.Database;
using BLHX.Server.Common.Utils;

namespace BLHX.Server.Game.Commands;

[CommandHandler("setlevel", "set a player's level", "setlevel uid=1 level=20")]
public class SetLevelCommand : Command {

    [Argument("uid")]
    public string? UID { get; set; }

    [Argument("level")]
    public string? Level { get; set; }

    public override void Execute(Dictionary<string, string> args) {
        base.Execute(args);

        if (UID is null || Level is null) {
            Logger.c.Log($"Usage: /setlevel uid=1 level=20");
            return;
        }

        if (!uint.TryParse(UID, out uint targetUID) || !uint.TryParse(Level, out uint targetLevel)) {
            Logger.c.Log($"Invalid UID or Level");
            return;
        }

        Player? player = DBManager.PlayerContext.Players.Where(p => p.Uid == targetUID).FirstOrDefault();

        if (player == null) {
            Logger.c.Log($"Can not find player with UID: ${targetUID}");
            return;
        }

        player.Level = targetLevel;

        DBManager.PlayerContext.Save();
        Logger.c.Log($"Set Player with UID {targetUID}'s level to {targetLevel}");
    }
}
