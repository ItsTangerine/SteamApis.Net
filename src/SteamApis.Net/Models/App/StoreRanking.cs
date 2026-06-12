using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class StoreRanking
{
    [JsonPropertyName("category")]
    public required string Category { get; init; }

    [JsonPropertyName("apps")]
    public required IReadOnlyList<RankedApp> Apps { get; init; }

    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; init; }
}