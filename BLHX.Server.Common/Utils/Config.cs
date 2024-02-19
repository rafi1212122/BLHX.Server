namespace BLHX.Server.Common.Utils;

public class Config : Singleton<Config>
{
    public string Address { get; set; } = "192.168.1.4";
    public uint Port { get; set; } = 20000;

    public static void Load()
    {
        Instance = JSON.Load<Config>(JSON.ConfigPath);

#if DEBUG
        Logger.c.Log($"Loaded Config:\n{JSON.Stringify(Instance)}");
#endif
    }

    public static void Save()
    {
        JSON.Save(JSON.ConfigPath, Instance);

#if DEBUG
        Logger.c.Log("Saved Config");
#endif
    }
}
