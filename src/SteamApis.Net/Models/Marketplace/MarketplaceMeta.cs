using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public sealed class MarketplaceMeta
{
    [JsonPropertyName("marketplace")]
    public required string Marketplace { get; init; }

    [JsonPropertyName("games")]
    public required IReadOnlyList<MarketplaceGameInfo> Games { get; init; }
}