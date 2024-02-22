using System.Text.Json.Serialization;

namespace BLHX.Server.Common.Data
{
    public class ResourceFieldTemplate : Model
    {
        [JsonPropertyName("hour_time")]
        public uint HourTime { get; set; }

        [JsonPropertyName("level")]
        public uint Level { get; set; }

        [JsonPropertyName("production")]
        public uint Production { get; set; }

        [JsonPropertyName("store")]
        public uint Store { get; set; }

        [JsonPropertyName("time")]
        public uint Time { get; set; }

        [JsonPropertyName("use")]
        public List<uint> Use { get; set; } = [];

        [JsonPropertyName("user_level")]
        public uint UserLevel { get; set; }
    }
}
