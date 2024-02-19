using BLHX.Server.Common.Utils;

namespace BLHX.Server.Game.Commands;

[commandHandler("test", "Test command", "test type=gacha")]
public class TestCommand : Command
{
    static readonly string[] RarityStrings = { "Unknown", "Unused", "Normal", "Rare", "Elite", "SSR", "UR" };
    
    [Argument("type")]
    public string? Type { get; set; }

    [Argument("count")]
    public string? Count { get; set; }

    [Argument("verbose")]
    public string? Verbose { get; set; }

    public override void Execute(Dictionary<string, string> args)
    {
        base.Execute(args);

        switch (Type)
        {
            case "gacha":
                TestGacha(Parse(Count, 1000000), Parse(Verbose, false));
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
}
