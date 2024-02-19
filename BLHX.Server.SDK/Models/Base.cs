using System.Text.Json.Serialization;

namespace BLHX.Server.SDK.Models
{
    class BaseResponse
    {
        [JsonPropertyName("result")]
        public int Result { get; set; }
    }
}
