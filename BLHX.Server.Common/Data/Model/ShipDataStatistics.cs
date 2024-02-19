using System.Text.Json.Serialization;

namespace BLHX.Server.Common.Data;

public class ShipDataStatistics : Model
{
    [JsonPropertyName("aim_offset")]
    public int[] AimOffset { get; set; }
    [JsonPropertyName("ammo")]
    public int Ammo { get; set; }
    [JsonPropertyName("armor_type")]
    public int ArmorType { get; set; }
    [JsonPropertyName("attack_duration")]
    public int AttackDuration { get; set; }
    [JsonPropertyName("attrs")]
    public float[] Attrs { get; set; }
    [JsonPropertyName("attrs_growth")]
    public float[] AttrsGrowth { get; set; }
    [JsonPropertyName("attrs_growth_extra")]
    public float[] AttrsGrowthExtra { get; set; }
    [JsonPropertyName("backyard_speed")]
    public string BackyardSpeed { get; set; }
    [JsonPropertyName("base_list")]
    public int[] BaseList { get; set; }
    [JsonPropertyName("cld_box")]
    public int[] CldBox { get; set; }
    [JsonPropertyName("cld_offset")]
    public int[] CldOffset { get; set; }
    [JsonPropertyName("default_equip_list")]
    public int[] DefaultEquipList { get; set; }
    [JsonPropertyName("depth_charge_list")]
    public int[] DepthChargeList { get; set; }
    [JsonPropertyName("english_name")]
    public string EnglishName { get; set; }
    [JsonPropertyName("equipment_proficiency")]
    public float[] EquipmentProficiency { get; set; }
    [JsonPropertyName("fix_equip_list")]
    public int[] FixEquipList { get; set; }
    [JsonPropertyName("hunting_range")]
    public object HuntingRange { get; set; }
    [JsonPropertyName("huntingrange_level")]
    public int HuntingRangeLevel { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("lock")]
    public string[] Lock { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("nationality")]
    public int Nationality { get; set; }
    [JsonPropertyName("oxy_cost")]
    public int OxyCost { get; set; }
    [JsonPropertyName("oxy_max")]
    public int OxyMax { get; set; }
    [JsonPropertyName("oxy_recovery")]
    public int OxyRecovery { get; set; }
    [JsonPropertyName("oxy_recovery_bench")]
    public int OxyRecoveryBench { get; set; }
    [JsonPropertyName("oxy_recovery_surface")]
    public int OxyRecoverySurface { get; set; }
    [JsonPropertyName("parallel_max")]
    public int[] ParallelMax { get; set; }
    [JsonPropertyName("position_offset")]
    public int[] PositionOffset { get; set; }
    [JsonPropertyName("preload_count")]
    public int[] PreloadCount { get; set; }
    [JsonPropertyName("raid_distance")]
    public int RaidDistance { get; set; }
    [JsonPropertyName("rarity")]
    public int Rarity { get; set; }
    [JsonPropertyName("scale")]
    public int Scale { get; set; }
    [JsonPropertyName("skin_id")]
    public int SkinId { get; set; }
    [JsonPropertyName("star")]
    public int Star { get; set; }
    [JsonPropertyName("strategy_list")]
    public int[][] StrategyList { get; set; }
    [JsonPropertyName("summon_offset")]
    public int SummonOffset { get; set; }
    [JsonPropertyName("tag_list")]
    public string[] TagList { get; set; }
    [JsonPropertyName("type")]
    public int Type { get; set; }
}
