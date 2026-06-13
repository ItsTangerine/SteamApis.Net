using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Items;

public record SafeTimeSeries
{
    [JsonPropertyName("last_24h")]
    public decimal Last24Hours { get; init; }

    [JsonPropertyName("last_7d")]
    public decimal Last7Days { get; init; }

    [JsonPropertyName("last_30d")]
    public decimal Last30Days { get; init; }

    [JsonPropertyName("last_90d")]
    public decimal Last90Days { get; init; }
}