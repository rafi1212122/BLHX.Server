using BLHX.Server.Common.Utils;

namespace BLHX.Server.Game.Commands;

[commandHandler("save", "Save the current state", "save")]
public class SaveCommand : Command
{
    public override void Execute(Dictionary<string, string> args)
    {
        base.Execute(args);

        Logger.c.Log("Saving...");
        Logger.c.Log("Saved!");
    }
}
