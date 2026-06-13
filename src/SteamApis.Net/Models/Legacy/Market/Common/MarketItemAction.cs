using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Common;

public record MarketItemAction
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("link")]
    public string Link { get; init; } = null!;
}