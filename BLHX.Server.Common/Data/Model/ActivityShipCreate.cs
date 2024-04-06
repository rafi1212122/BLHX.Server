using System.Text.Json.Serialization;

namespace BLHX.Server.Common.Data {
    public class ActivityShipCreate {
        [JsonPropertyName("activity_id")]
        public uint ActivityId { get; set; }

        [JsonPropertyName("create_id")]
        public uint CreateId { get; set; }

        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("pickup_list")]
        public uint[] PickupList { get; set; }

        [JsonPropertyName("pickup_num")]
        public uint PickupNum { get; set; }

        [JsonPropertyName("ratio_display")]
        public uint[] RatioDisplay { get; set; }
    }
}
