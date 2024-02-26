using System.Text.Json.Serialization;

namespace BLHX.Server.Common.Data
{
    public class BattleCostTemplate
    {
        [JsonPropertyName("attack_count")]
        public uint AttackCount { get; set; }

        [JsonPropertyName("cat_exp_award")]
        public uint CatExpAward { get; set; }

        [JsonPropertyName("end_sink_cost")]
        public uint EndSinkCost { get; set; }

        [JsonPropertyName("enter_energy_cost")]
        public uint EnterEnergyCost { get; set; }

        [JsonPropertyName("global_buff_effected")]
        public uint GlobalBuffEffected { get; set; }

        [JsonPropertyName("id")]
        public uint Id { get; set; }

        [JsonPropertyName("oil_cost")]
        public uint OilCost { get; set; }

        [JsonPropertyName("ship_exp_award")]
        public uint ShipExpAward { get; set; }

        [JsonPropertyName("user_exp_award")]
        public uint UserExpAward { get; set; }
    }
}
