using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Items;

public record SafeTimeSeries
{
    [JsonPropertyName("last_24h")]
    public decimal Last24h { get; init; }

    [JsonPropertyName("last_7d")]
    public decimal Last7d { get; init; }

    [JsonPropertyName("last_30d")]
    public decimal Last30d { get; init; }

    [JsonPropertyName("last_90d")]
    public decimal Last90d { get; init; }
}