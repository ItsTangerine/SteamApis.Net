using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public sealed class MarketplaceSnapshot
{
    [JsonPropertyName("marketplace")]
    public required string Marketplace { get; init; }

    [JsonPropertyName("priceUSD")]
    public double? PriceUsd { get; init; }

    [JsonPropertyName("priceEUR")]
    public double? PriceEur { get; init; }

    [JsonPropertyName("priceCNY")]
    public double? PriceCny { get; init; }

    [JsonPropertyName("priceRUB")]
    public double? PriceRub { get; init; }

    [JsonPropertyName("offerCount")]
    public long OfferCount { get; init; }

    [JsonPropertyName("updatedAt")]
    public long UpdatedAt { get; init; }
}