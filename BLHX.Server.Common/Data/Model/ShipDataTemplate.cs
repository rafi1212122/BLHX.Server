using System.Text.Json.Serialization;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace BLHX.Server.Common.Data
{
    public partial class ShipDataTemplate : Model
    {
        [JsonPropertyName("airassist_time")]
        public List<uint> AirassistTime { get; set; }

        [JsonPropertyName("buff_list")]
        public List<uint> BuffList { get; set; }

        [JsonPropertyName("buff_list_display")]
        public List<uint> BuffListDisplay { get; set; }

        [JsonPropertyName("can_get_proficency")]
        public uint CanGetProficency { get; set; }

        [JsonPropertyName("energy")]
        public uint Energy { get; set; }

        [JsonPropertyName("equip_1")]
        public List<uint> Equip1 { get; set; }

        [JsonPropertyName("equip_2")]
        public List<uint> Equip2 { get; set; }

        [JsonPropertyName("equip_3")]
        public List<uint> Equip3 { get; set; }

        [JsonPropertyName("equip_4")]
        public List<uint> Equip4 { get; set; }

        [JsonPropertyName("equip_5")]
        public List<uint> Equip5 { get; set; }

        [JsonPropertyName("equip_id_1")]
        public uint EquipId1 { get; set; }

        [JsonPropertyName("equip_id_2")]
        public uint EquipId2 { get; set; }

        [JsonPropertyName("equip_id_3")]
        public uint EquipId3 { get; set; }

        [JsonPropertyName("group_type")]
        public uint GroupType { get; set; }

        [JsonPropertyName("hide_buff_list")]
        public List<uint> HideBuffList { get; set; }

        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("max_level")]
        public uint MaxLevel { get; set; }

        [JsonPropertyName("oil_at_end")]
        public uint OilAtEnd { get; set; }

        [JsonPropertyName("oil_at_start")]
        public uint OilAtStart { get; set; }

        [JsonPropertyName("specific_type")]
        public List<string> SpecificType { get; set; }

        [JsonPropertyName("star")]
        public uint Star { get; set; }

        [JsonPropertyName("star_max")]
        public uint StarMax { get; set; }

        [JsonPropertyName("strengthen_id")]
        public uint StrengthenId { get; set; }

        [JsonPropertyName("type")]
        public uint Type { get; set; }
    }
}
