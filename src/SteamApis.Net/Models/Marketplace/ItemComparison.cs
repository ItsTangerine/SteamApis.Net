using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public sealed class ItemComparison
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("marketplaces")]
    public required IReadOnlyList<MarketplaceSnapshot> Marketplaces { get; init; }
}