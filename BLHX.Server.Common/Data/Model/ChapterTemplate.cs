using System.Text.Json;
using System.Text.Json.Serialization;

namespace BLHX.Server.Common.Data;

public enum ChapterAttachFlag
{
    AttachNone = 0,
    AttachBorn = 1,
    AttachBox = 2,
    AttachSupply = 3,
    AttachElite = 4,
    AttachAmbush = 5,
    AttachEnemy = 6,
    AttachTorpedo_Enemy = 7,
    AttachBoss = 8,
    AttachStory = 9,
    AttachAreaBoss = 11,
    AttachChampion = 12,
    AttachTorpedo_Fleet = 14,
    AttachChampionPatrol = 15,
    AttachBorn_Sub = 16,
    AttachTransport = 17,
    AttachTransport_Target = 18,
    AttachChampionSub = 19,
    AttachOni = 20,
    AttachOni_Target = 21,
    AttachBomb_Enemy = 24,
    AttachBarrier = 25,
    AttachHugeSupply = 26,
    AttachLandbase = 100
}

public class ChapterTemplate : Model
{
    [JsonIgnore]
    public List<GridItem> GridItems 
    { 
        get 
        {
            return Grids.Select(x => new GridItem() { Row = x[0].GetUInt32(), Column = x[1].GetUInt32(), Blocking = x[2].GetBoolean(), Flag = (ChapterAttachFlag)x[3].GetInt32() }).ToList();
        } 
    }

    [JsonPropertyName("ItemTransformPattern")]
    public object ItemTransformPattern { get; set; }
    [JsonPropertyName("act_id")]
    public int ActId { get; set; }
    [JsonPropertyName("ai_expedition_list")]
    public int[] AiExpeditionList { get; set; }
    [JsonPropertyName("ai_refresh")]
    public int[] AiRefresh { get; set; }
    [JsonPropertyName("air_dominance")]
    public int AirDominance { get; set; }
    [JsonPropertyName("alarm_cell")]
    public object AlarmCell { get; set; }
    [JsonPropertyName("ambush_event_ratio")]
    public object AmbushEventRatio { get; set; }
    [JsonPropertyName("ambush_expedition_list")]
    public int[] AmbushExpeditionList { get; set; }
    [JsonPropertyName("ambush_ratio_extra")]
    public int[][] AmbushRatioExtra { get; set; }
    [JsonPropertyName("ammo_submarine")]
    public int AmmoSubmarine { get; set; }
    [JsonPropertyName("ammo_total")]
    public int AmmoTotal { get; set; }
    [JsonPropertyName("avoid_ratio")]
    public int AvoidRatio { get; set; }
    [JsonPropertyName("avoid_require")]
    public int AvoidRequire { get; set; }
    [JsonPropertyName("awards")]
    public int[][] Awards { get; set; }
    [JsonPropertyName("best_air_dominance")]
    public int BestAirDominance { get; set; }
    [JsonPropertyName("bg")]
    public string Background { get; set; }
    [JsonPropertyName("bgm")]
    public string BackgroundMusic { get; set; }
    [JsonPropertyName("boss_expedition_id")]
    public int[] BossExpeditionId { get; set; }
    [JsonPropertyName("boss_refresh")]
    public int BossRefresh { get; set; }
    [JsonPropertyName("box_list")]
    public object BoxList { get; set; }
    [JsonPropertyName("box_refresh")]
    public int[] BoxRefresh { get; set; }
    [JsonPropertyName("chapter_fx")]
    public object ChapterFx { get; set; }
    [JsonPropertyName("chapter_name")]
    public string ChapterName { get; set; }
    [JsonPropertyName("chapter_strategy")]
    public object ChapterStrategy { get; set; }
    [JsonPropertyName("chapter_tag")]
    public int ChapterTag { get; set; }
    [JsonPropertyName("collection_team")]
    public int CollectionTeam { get; set; }
    [JsonPropertyName("count")]
    public int Count { get; set; }
    [JsonPropertyName("defeat_story")]
    public object DefeatStory { get; set; }
    [JsonPropertyName("defeat_story_count")]
    public object DefeatStoryCount { get; set; }
    [JsonPropertyName("difficulty")]
    public int Difficulty { get; set; }
    [JsonPropertyName("elite_expedition_list")]
    public int[] EliteExpeditionList { get; set; }
    [JsonPropertyName("elite_refresh")]
    public int[] EliteRefresh { get; set; }
    [JsonPropertyName("enemy_refresh")]
    public int[] EnemyRefresh { get; set; }
    [JsonPropertyName("enter_story")]
    public string EnterStory { get; set; }
    [JsonPropertyName("enter_story_limit")]
    public string EnterStoryLimit { get; set; }
    [JsonPropertyName("event_skip")]
    public int EventSkip { get; set; }
    [JsonPropertyName("expedition_id_weight_list")]
    public int[][] ExpeditionIdWeightList { get; set; }
    [JsonPropertyName("float_items")]
    public object FloatItems { get; set; }
    [JsonPropertyName("formation")]
    public int Formation { get; set; }
    [JsonPropertyName("friendly_id")]
    public int FriendlyId { get; set; }
    [JsonPropertyName("grids")]
    public List<List<JsonElement>> Grids { get; set; }
    [JsonPropertyName("group_num")]
    public int GroupNum { get; set; }
    [JsonPropertyName("guarder_expedition_list")]
    public int[] GuarderExpeditionList { get; set; }
    [JsonPropertyName("icon")]
    public string[] Icon { get; set; }
    [JsonPropertyName("icon_outline")]
    public int IconOutline { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("investigation_ratio")]
    public int InvestigationRatio { get; set; }
    [JsonPropertyName("is_ai")]
    public int IsAi { get; set; }
    [JsonPropertyName("is_air_attack")]
    public int IsAirAttack { get; set; }
    [JsonPropertyName("is_ambush")]
    public int IsAmbush { get; set; }
    [JsonPropertyName("is_limit_move")]
    public int IsLimitMove { get; set; }
    [JsonPropertyName("land_based")]
    public object LandBased { get; set; }
    [JsonPropertyName("levelstage_bar")]
    public string LevelStageBar { get; set; }
    [JsonPropertyName("limitation")]
    public object Limitation { get; set; }
    [JsonPropertyName("lose_condition")]
    public int[][] LoseCondition { get; set; }
    [JsonPropertyName("lose_condition_display")]
    public string LoseConditionDisplay { get; set; }
    [JsonPropertyName("map")]
    public int Map { get; set; }
    [JsonPropertyName("mitigation_level")]
    public int MitigationLevel { get; set; }
    [JsonPropertyName("mitigation_rate")]
    public int MitigationRate { get; set; }
    [JsonPropertyName("model")]
    public int Model { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("npc_data")]
    public object NpcData { get; set; }
    [JsonPropertyName("num_1")]
    public int Num1 { get; set; }
    [JsonPropertyName("num_2")]
    public int Num2 { get; set; }
    [JsonPropertyName("num_3")]
    public int Num3 { get; set; }
    [JsonPropertyName("oil")]
    public int Oil { get; set; }
    [JsonPropertyName("patrolai_expedition_list")]
    public int[] PatrolAiExpeditionList { get; set; }
    [JsonPropertyName("patrolai_refresh")]
    public int[] PatrolAiRefresh { get; set; }
    [JsonPropertyName("pop_pic")]
    public string PopPic { get; set; }
    [JsonPropertyName("pos_x")]
    public string PosX { get; set; }
    [JsonPropertyName("pos_y")]
    public string PosY { get; set; }
    [JsonPropertyName("pre_chapter")]
    public int PreChapter { get; set; }
    [JsonPropertyName("pre_story")]
    public int PreStory { get; set; }
    [JsonPropertyName("profiles")]
    public string Profiles { get; set; }
    [JsonPropertyName("progress_boss")]
    public int ProgressBoss { get; set; }
    [JsonPropertyName("property_limitation")]
    public object PropertyLimitation { get; set; }
    [JsonPropertyName("random_box_list")]
    public int[] RandomBoxList { get; set; }
    [JsonPropertyName("risk_levels")]
    public int[][] RiskLevels { get; set; }
    [JsonPropertyName("scale")]
    public double[] Scale { get; set; }
    [JsonPropertyName("special_operation_list")]
    public string SpecialOperationList { get; set; }
    [JsonPropertyName("star_require_1")]
    public int StarRequire1 { get; set; }
    [JsonPropertyName("star_require_2")]
    public int StarRequire2 { get; set; }
    [JsonPropertyName("star_require_3")]
    public int StarRequire3 { get; set; }
    [JsonPropertyName("story_refresh")]
    public object StoryRefresh { get; set; }
    [JsonPropertyName("story_refresh_boss")]
    public string StoryRefreshBoss { get; set; }
    [JsonPropertyName("submarine_expedition_list")]
    public int[] SubmarineExpeditionList { get; set; }
    [JsonPropertyName("submarine_num")]
    public int SubmarineNum { get; set; }
    [JsonPropertyName("submarine_refresh")]
    public int[] SubmarineRefresh { get; set; }
    [JsonPropertyName("support_group_num")]
    public int SupportGroupNum { get; set; }
    [JsonPropertyName("theme")]
    public object Theme { get; set; }
    [JsonPropertyName("time")]
    public int Time { get; set; }
    [JsonPropertyName("type")]
    public int Type { get; set; }
    [JsonPropertyName("uifx")]
    public string UiFx { get; set; }
    [JsonPropertyName("unlocklevel")]
    public int UnlockLevel { get; set; }
    [JsonPropertyName("use_oil_limit")]
    public object UseOilLimit { get; set; }
    [JsonPropertyName("wall_prefab")]
    public object WallPrefab { get; set; }
    [JsonPropertyName("weather_grids")]
    public object WeatherGrids { get; set; }
    [JsonPropertyName("win_condition")]
    public object WinCondition { get; set; }
    [JsonPropertyName("win_condition_display")]
    public string WinConditionDisplay { get; set; }
}

public readonly struct GridItem
{
    public uint Row { get; init; }
    public uint Column { get; init; }
    public bool Blocking { get; init; }
    public ChapterAttachFlag Flag { get; init; }
}