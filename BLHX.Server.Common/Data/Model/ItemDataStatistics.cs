using System.Text.Json.Serialization;

namespace BLHX.Server.Common.Data;

public class ItemDataStatistics : Model {
    [JsonPropertyName("combination_display")]
    public int[] CombinationDisplay { get; set; } // Empty array implies List<object>

    [JsonPropertyName("compose_number")]
    public int ComposeNumber { get; set; }

    [JsonPropertyName("display")]
    public string Display { get; set; }

    [JsonPropertyName("display_effect")]
    public string DisplayEffect { get; set; }

    [JsonPropertyName("display_icon")]
    public object DisplayIcon { get; set; }

    [JsonPropertyName("icon")]
    public string Icon { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("index")]
    public int[] Index { get; set; } // Assuming empty array

    [JsonPropertyName("is_world")]
    public int IsWorld { get; set; }

    [JsonPropertyName("limit")]
    public string Limit { get; set; }

    [JsonPropertyName("link_id")]
    public int LinkId { get; set; }

    [JsonPropertyName("max_num")]
    public int MaxNum { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("open_directly")]
    public int OpenDirectly { get; set; }

    [JsonPropertyName("order")]
    public int Order { get; set; }

    [JsonPropertyName("other_item_cost")]
    public string OtherItemCost { get; set; }

    [JsonPropertyName("other_resource_cost")]
    public string OtherResourceCost { get; set; }

    [JsonPropertyName("price")]
    public object Price { get; set; }

    [JsonPropertyName("rarity")]
    public int Rarity { get; set; }

    [JsonPropertyName("replace_item")]
    public int ReplaceItem { get; set; }

    [JsonPropertyName("shiptrans_id")]
    public int[] ShiptransId { get; set; } // Assuming empty array

    [JsonPropertyName("target_id")]
    public int TargetId { get; set; }

    [JsonPropertyName("time_limit")]
    public int TimeLimit { get; set; }

    [JsonPropertyName("type")]
    public int Type { get; set; }

    [JsonPropertyName("usage")]
    public string Usage { get; set; }

    [JsonPropertyName("usage_arg")]
    public object UsageArg { get; set; }

    [JsonPropertyName("virtual_type")]
    public int VirtualType { get; set; }
}
