namespace BLHX.Server.Common.Utils;

public static class RNG
{
    public enum Rarity {
        Normal = 2,
        Rare = 3,
        Elite = 4,
        SSR = 5,
        UR = 6,
    }

    public static readonly SortedDictionary<int, float> ShipRarityRates = new()
    {
        {6, 1.2f},  // UR
        {5, 7f},    // SSR
        {4, 12f},   // Elite
        {2, 28.8f}, // Normal
        {3, 51f},   // Rare
    };

    static readonly Random random = new Random((int)DateTime.Now.Ticks);

    public static int Next(int min, int max)
        => random.Next(min, max);

    public static int Next(int max)
        => random.Next(max);
    
    public static float NextFloat(float min, float max)
    {
        double range = (double)max - min;
        double sample = random.NextDouble();
        double scaled = (sample * range) + min;

        return (float)scaled;
    }

    public static float NextFloat(float max)
        => NextFloat(0f, max);
    
    public static bool NextBool()
        => random.Next(2) == 0;

    public static float NextRoll()
        => NextFloat(100f);
    
    public static T NextFromList<T>(IList<T> list)
        => list[random.Next(list.Count)];

    public static U NextFromDict<T, U>(IDictionary<T, U> dict)
        => dict.ElementAt(random.Next(dict.Count)).Value;

    public static int NextFromRarityDict(SortedDictionary<int, float> dict)
    {
        float roll = NextRoll();
        float sum = 0f;

        foreach (var pair in dict)
        {
            sum += pair.Value;
            if (roll <= sum)
                return pair.Key;
        }

        throw new Exception("NextFromRarityDict() roll failed");
    }

    public static int NextShipRarity()
        => NextFromRarityDict(ShipRarityRates);
}
