using System.Text.Json.Serialization;

namespace BLHX.Server.Common.Data;

public class TaskDateTemplate : Model
{
    [JsonPropertyName("activity_client_config")]
    public object ActivityClientConfig { get; set; }
    [JsonPropertyName("added_tip")]
    public int AddedTip { get; set; }
    [JsonPropertyName("auto_commit")]
    public int AutoCommit { get; set; }
    [JsonPropertyName("award")]
    public int Award { get; set; }
    [JsonPropertyName("award_choice")]
    public object AwardChoice { get; set; }
    [JsonPropertyName("award_display")]
    public object AwardDisplay { get; set; }
    [JsonPropertyName("count_inherit")]
    public int CountInherit { get; set; }
    [JsonPropertyName("desc")]
    public string Description { get; set; }
    [JsonPropertyName("fix_task")]
    public int FixTask { get; set; }
    [JsonPropertyName("guild_coin_award")]
    public int GuildCoinAward { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("is_head")]
    public int IsHead { get; set; }
    [JsonPropertyName("level")]
    public int Level { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("next_task")]
    public string NextTask { get; set; }
    [JsonPropertyName("open_need")]
    public object OpenNeed { get; set; }
    [JsonPropertyName("priority_type")]
    public int PriorityType { get; set; }
    [JsonPropertyName("quick_finish")]
    public int QuickFinish { get; set; }
    [JsonPropertyName("ryza_icon")]
    public string RyzaIcon { get; set; }
    [JsonPropertyName("ryza_type")]
    public int RyzaType { get; set; }
    [JsonPropertyName("scene")]
    public object Scene { get; set; }
    [JsonPropertyName("story_icon")]
    public string StoryIcon { get; set; }
    [JsonPropertyName("story_icon_shift")]
    public object StoryIconShift { get; set; }
    [JsonPropertyName("story_id")]
    public string StoryId { get; set; }
    [JsonPropertyName("sub_type")]
    public int SubType { get; set; }
    [JsonPropertyName("target_id")]
    public object TargetId { get; set; }
    [JsonPropertyName("target_id_2")]
    public object TargetId2 { get; set; }
    [JsonPropertyName("target_num")]
    public int TargetNum { get; set; }
    [JsonPropertyName("task_fold")]
    public int TaskFold { get; set; }
    [JsonPropertyName("type")]
    public int Type { get; set; }
    [JsonPropertyName("visibility")]
    public int Visibility { get; set; }
}
