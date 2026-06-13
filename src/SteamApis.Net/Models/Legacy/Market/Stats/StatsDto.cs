using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Stats;

public record StatsDto
{
    [JsonPropertyName("totalSpent")]
    public double? TotalSpent { get; init; }

    [JsonPropertyName("totalCount")]
    public long? TotalCount { get; init; }

    [JsonPropertyName("totalApps")]
    public int? TotalApps { get; init; }
}