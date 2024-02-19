using BLHX.Server.Common.Utils;

namespace BLHX.Server.Common.Data;

public class Config : Singleton<Config>
{
    public string Address { get; set; } = "127.0.0.1";
    public uint Port { get; set; } = 20000;

    public static void Load()
    {
        Instance = JSON.Load<Config>(JSON.ConfigPath);

        Logger.c.Log($"Config loaded");
    }

    public static void Save()
    {
        JSON.Save(JSON.ConfigPath, Instance);

        Logger.c.Log("Config saved");
    }
}
