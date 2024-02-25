using BLHX.Server.Common.Data;
using BLHX.Server.Common.Utils;

namespace BLHX.Server.Game.Commands;

[CommandHandler("test", "Test command", "test type=gacha")]
public class TestCommand : Command
{
    static readonly string[] RarityStrings = { "Unknown", "Unused", "Normal", "Rare", "Elite", "SSR", "UR" };
    
    [Argument("type")]
    public string? Type { get; set; }

    [Argument("verbose")]
    public string? Verbose { get; set; }
    
    [Argument("count")]
    public string? Count { get; set; }

    [Argument("value")]
    public string? Value { get; set; }
    
    public override void Execute(Dictionary<string, string> args)
    {
        base.Execute(args);

        switch (Type)
        {
            case "gacha":
                TestGacha(Parse(Count, 1000000), Parse(Verbose, false));
                break;
            case "lookup":
                LookupShip(Parse(Value, 1));
                break;
            case "pathfinding":
                TestPathfinding();
                break;
            default:
                Logger.c.Warn("Unknown test type");
                break;
        }
    }

    void TestGacha(int count, bool verbose)
    {
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var counts = new int[7];

        for (int i = 0; i < count; i++)
        {
            int rarity = RNG.NextShipRarity();

            counts[rarity]++;

            if (verbose)
                Logger.c.Log($"Roll {i + 1}: {rarity} - {RarityStrings[rarity]}");
        }

        stopwatch.Stop();

        Logger.c.Log("----------------------------------------");
        Logger.c.Log($"TOTAL ROLLS: {count}");
        Logger.c.Log($"PROCESSING TIME: {stopwatch.Elapsed}");

        for (int i = 2; i < counts.Length; i++)
        {
            double percentage = (double)Math.Round(counts[i] / (double)count * 100, 2);

            Logger.c.Log($"{RarityStrings[i]}: {counts[i]} ({percentage}%)");
        }
    }

    void LookupShip(int id)
    {
        ShipDataStatistics? ship = Data.ShipDataStatistics.GetValueOrDefault(id);

        if (ship != null)
            Logger.c.Log($"Ship {id} ({ship.EnglishName}):\n{JSON.Stringify(ship)}");
        else
            Logger.c.Warn($"Ship {id} not found");
    }

    void TestPathfinding()
    {
        bool verbose = Parse(Verbose, true);
        var stopwatch = System.Diagnostics.Stopwatch.StartNew();
        var grid = Data.ChapterTemplate[103].GridItems;
        (uint startX, uint startY, uint width, uint height) = grid.GetDimensions();
        var path = Pathfinding.AStar(grid, 0, 0, width - 1, height - 1);

        if (verbose)
        {
            Logger.c.Log("TEST GRID:");
            for (uint x = 0; x < width; x++)
            {
                for (uint y = 0; y < height; y++)
                {
                    var gridItem = grid.Find(x, y).Value;

                    if (gridItem.Column >= startX && gridItem.Column <= width &&
                        gridItem.Row >= startY && gridItem.Row <= height)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else if (x == 0 && y == 0)
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    else if (x == width - 1 && y == height - 1)
                        Console.ForegroundColor = ConsoleColor.Yellow;

                    Console.Write(grid.Find(x, y).Value.Blocking ? "1" : "0");
                    Console.ResetColor();
                }

                Console.WriteLine();
            }
        }
        
        if (path != null)
        {
            Logger.c.Log($"Path found! Length: {path.Count}");
            
            if (verbose)
                foreach (var node in path)
                    Logger.c.Log(node.ToString());
        }
        else
            Logger.c.Warn("No path found!");
        
        stopwatch.Stop();
        
        Logger.c.Log("----------------------------------------");
        Logger.c.Log($"PROCESSING TIME: {stopwatch.Elapsed}");
    }
}
