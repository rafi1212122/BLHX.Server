using System.Text.Json.Serialization;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace BLHX.Server.Common.Data
{
    public class ShipSkinTemplate
    {
        [JsonPropertyName("bg")]
        public string Bg { get; set; }

        [JsonPropertyName("bg_sp")]
        public string BgSp { get; set; }

        [JsonPropertyName("bgm")]
        public string Bgm { get; set; }

        [JsonPropertyName("bound_bone")]
        public dynamic BoundBone { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("fx_container")]
        public List<List<double>> FxContainer { get; set; }

        [JsonPropertyName("group_index")]
        public int GroupIndex { get; set; }

        [JsonPropertyName("gyro")]
        public int Gyro { get; set; }

        [JsonPropertyName("hand_id")]
        public int HandId { get; set; }

        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("illustrator")]
        public int Illustrator { get; set; }

        [JsonPropertyName("illustrator2")]
        public int Illustrator2 { get; set; }

        [JsonPropertyName("l2d_animations")]
        public dynamic L2DAnimations { get; set; }

        [JsonPropertyName("l2d_drag_rate")]
        public dynamic L2DDragRate { get; set; }

        [JsonPropertyName("l2d_ignore_drag")]
        public long L2DIgnoreDrag { get; set; }

        [JsonPropertyName("l2d_para_range")]
        public dynamic L2DParaRange { get; set; }

        [JsonPropertyName("l2d_se")]
        public dynamic L2DSe { get; set; }

        [JsonPropertyName("l2d_voice_calibrate")]
        public dynamic L2DVoiceCalibrate { get; set; }

        [JsonPropertyName("lip_smoothing")]
        public int LipSmoothing { get; set; }

        [JsonPropertyName("lip_sync_gain")]
        public int LipSyncGain { get; set; }

        [JsonPropertyName("live2d_offset")]
        public dynamic Live2DOffset { get; set; }

        [JsonPropertyName("live2d_offset_profile")]
        public dynamic Live2DOffsetProfile { get; set; }

        [JsonPropertyName("main_UI_FX")]
        public string MainUiFx { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("painting")]
        public string Painting { get; set; }

        [JsonPropertyName("prefab")]
        public string Prefab { get; set; }

        [JsonPropertyName("rarity_bg")]
        public string RarityBg { get; set; }

        [JsonPropertyName("ship_group")]
        public uint ShipGroup { get; set; }

        [JsonPropertyName("ship_l2d_id")]
        public dynamic ShipL2DId { get; set; }

        [JsonPropertyName("shop_id")]
        public uint ShopId { get; set; }

        [JsonPropertyName("shop_type_id")]
        public int ShopTypeId { get; set; }

        [JsonPropertyName("show_skin")]
        public string ShowSkin { get; set; }

        [JsonPropertyName("skin_type")]
        public int SkinType { get; set; }

        [JsonPropertyName("smoke")]
        public dynamic Smoke { get; set; }

        [JsonPropertyName("special_effects")]
        public dynamic SpecialEffects { get; set; }

        [JsonPropertyName("spine_action_offset")]
        public dynamic SpineActionOffset { get; set; }

        [JsonPropertyName("spine_offset")]
        public dynamic SpineOffset { get; set; }

        [JsonPropertyName("tag")]
        public List<int> Tag { get; set; }

        [JsonPropertyName("time")]
        public dynamic Time { get; set; }

        [JsonPropertyName("voice_actor")]
        public int VoiceActor { get; set; }

        [JsonPropertyName("voice_actor_2")]
        public int VoiceActor2 { get; set; }
    }
}
