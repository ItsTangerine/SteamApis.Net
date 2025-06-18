using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Stats;

public record GlobalStatsResponse
{
    [JsonPropertyName("count")]
    public long? Count { get; init; }

    [JsonPropertyName("stats")]
    public StatsDto? Stats { get; init; }

    [JsonPropertyName("updated_at")]
    public long? UpdatedAt { get; init; }
}