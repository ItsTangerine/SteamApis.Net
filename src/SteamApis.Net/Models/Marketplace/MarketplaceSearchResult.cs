using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public sealed class MarketplaceSearchResult
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("marketplace")]
    public required string Marketplace { get; init; }

    [JsonPropertyName("game")]
    public required string Game { get; init; }

    [JsonPropertyName("priceUSD")]
    public double? PriceUsd { get; init; }

    [JsonPropertyName("offerCount")]
    public long OfferCount { get; init; }

    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    [JsonPropertyName("updatedAt")]
    public long UpdatedAt { get; init; }
}