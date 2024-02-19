using BLHX.Server.Common.Utils;

namespace BLHX.Server.Common.Data;

public static class Data
{
    static readonly Logger c = new(nameof(Data), ConsoleColor.Yellow);

    public static Dictionary<int, ChapterTemplate> ChapterTemplate;
    public static Dictionary<int, ShipDataStatistics> ShipDataStatistics;
    public static Dictionary<int, TaskDateTemplate> TaskDataTemplate;

    public static void Load()
    {
        LoadData(ref ChapterTemplate, "chapter_template.json", nameof(ChapterTemplate));
        LoadData(ref ShipDataStatistics, "ship_data_statistics.json", nameof(ShipDataStatistics));
        LoadData(ref TaskDataTemplate, "task_data_template.json", nameof(TaskDataTemplate));

        c.Log("All data tables loaded");
    }

    static void LoadData<T>(ref Dictionary<int, T> data, string fileName, string dataName)
    {
        try
        {
            data = JSON.Load<Dictionary<int, T>>(Path.Combine(JSON.ShareConfigPath, fileName));
            c.Warn($"Loaded {data.Count} {dataName}");
        }
        catch (Exception e)
        {
            c.Error(e.Message);
        }
    }
}
