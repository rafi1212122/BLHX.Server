using System.Text.Json;
using System.Text.RegularExpressions;

namespace BLHX.Server.Common.Data;

public static partial class JSON
{
    public static JsonSerializerOptions serializerOptions = new() { IncludeFields = true, WriteIndented = true };
    public static string ConfigPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config.json");
    public static string ShareCfgDataPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/sharecfgdata/");
    public static string ShareCfgPath => Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources/ShareCfg/");

    public static T Load<T>(string path, bool create = true) where T : new()
    {
        if (!File.Exists(path) && create)
        {
            T obj = new T();
            Save(path, obj);
        }

        string text = File.ReadAllText(path);
        if (typeof(T).IsGenericType && typeof(T).GetGenericTypeDefinition() == typeof(Dictionary<,>) && typeof(T).GetGenericArguments()[0] == typeof(int))
        {
            text = DictKeyAll().Replace(text, "");
        }

        return JsonSerializer.Deserialize<T>(text, serializerOptions) ?? new T();
    }

    public static void Save<T>(string path, T obj)
    {
        File.WriteAllText(path, JsonSerializer.Serialize(obj, serializerOptions));
    }

    public static string Stringify<T>(T obj)
    {
        return JsonSerializer.Serialize(obj, serializerOptions);
    }

    [GeneratedRegex(@",[\n\s\t]+?""all"":[\s\S]+?]", RegexOptions.Multiline)]
    public static partial Regex DictKeyAll();
}
