using System.Reflection;
using System.Text;

namespace BLHX.Server.Game.Commands;

[commandHandler("help", "Print out all commands with their description and example", "help")]
public class HelpCommand : Command
{
    static readonly Dictionary<Type, commandHandler?> commandAttributes = new Dictionary<Type, commandHandler?>();

    public override void Execute(Dictionary<string, string> args)
    {
        base.Execute(args);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Available Commands: ");
        foreach (var command in CommandHandler.Commands)
        {
            if (!commandAttributes.TryGetValue(command.GetType(), out var attr))
            {
                attr = command.GetType().GetCustomAttribute(typeof(commandHandler)) as commandHandler;
                commandAttributes[command.GetType()] = attr;
            }

            if (attr != null)
                sb.AppendLine($"  {attr.Name} - {attr.Description} (Example: {attr.Example})");
        }

        Console.Write(sb.ToString());
    }
}
