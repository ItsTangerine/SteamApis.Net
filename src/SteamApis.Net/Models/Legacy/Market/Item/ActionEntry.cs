using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Item;

public record ActionEntry
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("link")]
    public string Link { get; init; } = default!;
}