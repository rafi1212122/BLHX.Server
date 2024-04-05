using BLHX.Server.Common.Database;
using BLHX.Server.Common.Utils;
using BLHX.Server.Game.Handlers;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace BLHX.Server.Game.Commands;

// Chatbox has 40 character limit, original command is setplayerdata shortened -> spd
[CommandHandler("spd", "set a player's data", "spd property=level value=20")]
public class SetPlayerDataCommand : Command {

    [Argument("property")]
    public string? Property { get; set; }

    [Argument("value")]
    public string? Value { get; set; }

    public override void Execute(Dictionary<string, string> args, Connection connection) {
        base.Execute(args);

        if (Property is null || Value is null) {
            connection.SendSystemMsg($"Usage: /spd property=<Level|Name|Exp|ShipBagMax|...> value=1");
            return;
        }

        PropertyInfo? targetProperty = typeof(Player).GetProperty(Property);
        TypeConverter converter = TypeDescriptor.GetConverter(targetProperty.PropertyType);

        if (converter != null && converter.CanConvertFrom(typeof(string))) {
            try {
                object targetValue = converter.ConvertFromInvariantString(Value);

                targetProperty.SetValue(connection.player, targetValue);
            } catch (Exception) {
                connection.SendSystemMsg("Invalid Value");
                return;
            }
        } else {
            connection.SendSystemMsg($"Invalid Player Property!");
            return;
        }

        DBManager.PlayerContext.Save();
        connection.NotifyPlayerData();
        connection.SendSystemMsg($"Set Player with UID {connection.player.Uid}'s {Property} to {Value}");
    }
}
