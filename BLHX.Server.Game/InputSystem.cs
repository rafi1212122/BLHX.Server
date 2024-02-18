using BLHX.Server.Game.Commands;

namespace BLHX.Server.Game;

public static class InputSystem
{
    public static void Start()
    {
        while (true)
        {
            var command = Console.ReadLine();

            if (string.IsNullOrEmpty(command)) continue;

            CommandHandler.HandleCommand(command);
        }
    }
}
