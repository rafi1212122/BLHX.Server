using BLHX.Server.Common.Utils;
using System.Reflection;

namespace BLHX.Server.Common.Data;

public static class Data
{
    static readonly Logger c = new(nameof(Data), ConsoleColor.Yellow);

    [LoadData("oilfield_template.json", LoadDataType.ShareCfg)]
    public static Dictionary<int, ResourceFieldTemplate> OilFieldTemplate { get; private set; } = null!;
    
    [LoadData("tradingport_template.json", LoadDataType.ShareCfg)]
    public static Dictionary<int, ResourceFieldTemplate> GoldFieldTemplate { get; private set; } = null!;
    
    [LoadData("ship_skin_template.json", LoadDataType.ShareCfg)]
    public static Dictionary<int, ShipSkinTemplate> ShipSkinTemplate { get; private set; } = null!;
    
    [LoadData("battle_cost_template.json", LoadDataType.ShareCfg)]
    public static Dictionary<uint, BattleCostTemplate> BattleCostTemplate { get; private set; } = null!;
    
    [LoadData("chapter_template.json", LoadDataType.ShareCfgData)]
    public static Dictionary<int, ChapterTemplate> ChapterTemplate { get; private set; } = null!;
    
    [LoadData("ship_data_statistics.json", LoadDataType.ShareCfgData)]
    public static Dictionary<int, ShipDataStatistics> ShipDataStatistics { get; private set; } = null!;
    
    [LoadData("ship_data_template.json", LoadDataType.ShareCfgData)]
    public static Dictionary<int, ShipDataTemplate> ShipDataTemplate { get; private set; } = null!;
    
    [LoadData("task_data_template.json", LoadDataType.ShareCfgData)]
    public static Dictionary<int, TaskDateTemplate> TaskDataTemplate { get; private set; } = null!;

    [LoadData("item_data_statistics.json", LoadDataType.ShareCfgData)]
    public static Dictionary<int, ItemDataStatistics> ItemDataStatistics { get; private set; } = null!;

    public static void Load()
    {
        foreach (var prop in typeof(Data).GetProperties().Where(x => x.GetCustomAttribute<LoadDataAttribute>() is not null))
        {
            var attr = prop.GetCustomAttribute<LoadDataAttribute>()!;
            prop.SetValue(null, typeof(JSON).GetMethod("Load")!.MakeGenericMethod(prop.PropertyType).Invoke(null, [Path.Combine(attr.DataType switch
            {
                LoadDataType.ShareCfg => JSON.ShareCfgPath,
                LoadDataType.ShareCfgData => JSON.ShareCfgDataPath,
                _ => ""
            }, attr.FileName), false]));
            c.Warn($"Loaded {prop.Name}");
        }

        c.Log("All data tables loaded");
    }

    static void LoadData<T>(ref Dictionary<int, T> data, string fileName, string dataName)
    {
        try
        {
            data = JSON.Load<Dictionary<int, T>>(Path.Combine(JSON.ShareCfgDataPath, fileName));
            c.Warn($"Loaded {data.Count} {dataName}");
        }
        catch (Exception e)
        {
            c.Error(e.Message);
        }
    }
}

public enum LoadDataType
{
    ShareCfg,
    ShareCfgData
}

[AttributeUsage(AttributeTargets.Property)]
public class LoadDataAttribute(string fileName, LoadDataType dataType) : Attribute
{
    public LoadDataType DataType = dataType;
    public string FileName = fileName;
}