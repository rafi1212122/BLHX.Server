using BLHX.Server.Common.Utils;
using System.Reflection;

namespace BLHX.Server.Game.Commands;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class CommandHandler : Attribute
{
    public string Name { get; }
    public string Description { get; }
    public string Example { get; }

    public CommandHandler(string commandName, string description, string example)
    {
        Name = commandName;
        Description = description;
        Example = example;
    }

}

[AttributeUsage(AttributeTargets.Property)]
public class ArgumentAttribute : Attribute
{
    public string Key { get; }

    public ArgumentAttribute(string key)
    {
        Key = key;
    }
}

[Flags]
public enum CommandUsage
{
    None = 0,
    Console = 1,
    User = 2
}

public abstract class Command
{
    public virtual CommandUsage Usage 
    { 
        get
        {
            var usage = CommandUsage.None;
            if (GetType().GetMethod(nameof(Execute), [typeof(Dictionary<string, string>), typeof(Connection)])?.DeclaringType == GetType())
                usage |= CommandUsage.User;
            if (GetType().GetMethod(nameof(Execute), [typeof(Dictionary<string, string>)])?.DeclaringType ==  GetType())
                usage |= CommandUsage.Console;

            return usage;
        } 
    }

    readonly Dictionary<string, PropertyInfo> argsProperties;

    public Command()
    {
        argsProperties = GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
            .Where(x => Attribute.IsDefined(x, typeof(ArgumentAttribute)))
            .ToDictionary(x => ((ArgumentAttribute)Attribute.GetCustomAttribute(x, typeof(ArgumentAttribute))!).Key, StringComparer.OrdinalIgnoreCase);
    }

    public virtual void Execute(Dictionary<string, string> args)
    {
        foreach (var arg in args)
        {
            if (argsProperties.TryGetValue(arg.Key, out var prop))
                prop.SetValue(this, arg.Value);
        }
    }

    public virtual void Execute(Dictionary<string, string> args, Connection connection)
    {
        Execute(args);
    }

    protected T Parse<T>(string? value, T fallback = default!)
    {
        var tryParseMethod = typeof(T).GetMethod("TryParse", [typeof(string), typeof(T).MakeByRefType()]);

        if (tryParseMethod != null)
        {
            var parameters = new object[] { value!, null! };
            bool success = (bool)tryParseMethod.Invoke(null, parameters)!;

            if (success)
                return (T)parameters[1];
        }

        return fallback;
    }
}

public static class CommandHandlerFactory
{
    public static readonly List<Command> Commands = new List<Command>();
    
    static readonly Dictionary<string, Action<Dictionary<string, string>>> commandFunctions;
    static readonly Dictionary<string, Action<Dictionary<string, string>, Connection>> commandFunctionsConn;

    static CommandHandlerFactory()
    {
        commandFunctions = new Dictionary<string, Action<Dictionary<string, string>>>(StringComparer.OrdinalIgnoreCase);
        commandFunctionsConn = new Dictionary<string, Action<Dictionary<string, string>, Connection>>(StringComparer.OrdinalIgnoreCase);

        RegisterCommands(Assembly.GetExecutingAssembly());
    }

    public static void RegisterCommands(Assembly assembly)
    {
        var commandTypes = assembly.GetTypes()
            .Where(t => Attribute.IsDefined(t, typeof(CommandHandler)) && typeof(Command).IsAssignableFrom(t));

        foreach (var commandType in commandTypes)
        {
            var commandAttribute = (CommandHandler?)Attribute.GetCustomAttribute(commandType, typeof(CommandHandler));
            if (commandAttribute != null)
            {
                var commandInstance = (Command)Activator.CreateInstance(commandType)!;

                if (commandInstance.Usage.HasFlag(CommandUsage.Console))
                    commandFunctions[commandAttribute.Name] = commandInstance.Execute;
                if (commandInstance.Usage.HasFlag(CommandUsage.User))
                    commandFunctionsConn[commandAttribute.Name] = commandInstance.Execute;

                Commands.Add(commandInstance);
            }
        }
    }

    public static void HandleCommand(string commandLine, Connection? connection = null)
    {
        var parts = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        if (parts.Length == 0)
            return;

        var arguments = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
        for (var i = 1; i < parts.Length; i++)
        {
            var argParts = parts[i].Split('=', 2);
            if (argParts.Length == 2)
                arguments[argParts[0]] = argParts[1];
        }

        if (connection is not null)
        {
            if (!(commandFunctionsConn).TryGetValue(parts[0], out var command))
            {
                Logger.c.Warn($"Unknown command: {parts[0]}");
                return;
            }

            command(arguments, connection);
        }
        else
        {
            if (!(commandFunctions).TryGetValue(parts[0], out var command))
            {
                Logger.c.Warn($"Unknown command: {parts[0]}");
                return;
            }

            command(arguments);
        }
    }
}
