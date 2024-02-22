using BLHX.Server.Game.Handlers;
using System.Reflection;
using System.Text;

namespace BLHX.Server.Game.Commands;

[CommandHandler("help", "Print out all commands with their description and example", "help")]
public class HelpCommand : Command
{
    static readonly Dictionary<Type, CommandHandler?> commandAttributes = new Dictionary<Type, CommandHandler?>();

    public override void Execute(Dictionary<string, string> args)
    {
        base.Execute(args);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Available Commands: ");
        foreach (var command in CommandHandlerFactory.Commands.Where(x => x.Usage.HasFlag(CommandUsage.Console)))
        {
            if (!commandAttributes.TryGetValue(command.GetType(), out var attr))
            {
                attr = command.GetType().GetCustomAttribute(typeof(CommandHandler)) as CommandHandler;
                commandAttributes[command.GetType()] = attr;
            }

            if (attr != null)
                sb.AppendLine($"  {attr.Name} - {attr.Description} (Example: {attr.Example}), Usage: {command.Usage}");
        }

        Console.Write(sb.ToString());
    }

    public override void Execute(Dictionary<string, string> args, Connection connection)
    {
        base.Execute(args);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine("Available Commands: ");
        foreach (var command in CommandHandlerFactory.Commands.Where(x => x.Usage.HasFlag(CommandUsage.User)))
        {
            if (!commandAttributes.TryGetValue(command.GetType(), out var attr))
            {
                attr = command.GetType().GetCustomAttribute(typeof(CommandHandler)) as CommandHandler;
                commandAttributes[command.GetType()] = attr;
            }

            if (attr != null)
                sb.AppendLine($"  {attr.Name} - {attr.Description} (Example: {attr.Example})");
        }

        connection.SendSystemMsg(sb.ToString());
    }
}
