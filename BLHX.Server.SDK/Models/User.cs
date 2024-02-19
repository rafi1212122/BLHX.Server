using BLHX.Server.Sdk;
using System.Text.Json.Serialization;

namespace BLHX.Server.SDK.Models
{
    record UserCreateRequest(string ChannelId, string DeviceId) : BindableFormRequest<UserCreateRequest>;
    record UserLoginRequest(uint Uid, string StoreId, string DeviceId, string Platform, string Token) : BindableFormRequest<UserLoginRequest>;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    class UserLoginResponse : BaseResponse
    {
        [JsonPropertyName("accessToken")]
        public string AccessToken { get; set; }

        [JsonPropertyName("birth")]
        public dynamic? Birth { get; set; }

        [JsonPropertyName("channelId")]
        public string ChannelId { get; set; }

        [JsonPropertyName("current_timestamp_ms")]
        public long CurrentTimestampMs { get; set; }

        [JsonPropertyName("kr_kmc_status")]
        public int KrKmcStatus { get; set; }

        [JsonPropertyName("transcode")]
        public string TransCode { get; set; }
    }

    class UserCreateResponse : BaseResponse
    {
        [JsonPropertyName("uid")]
        public uint Uid { get; set; }

        [JsonPropertyName("token")]
        public string Token { get; set; }

        [JsonPropertyName("isNew")]
        public int IsNew { get; set; }
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
}
