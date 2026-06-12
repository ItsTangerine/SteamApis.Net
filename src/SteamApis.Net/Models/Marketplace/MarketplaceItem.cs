using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public sealed class MarketplaceItem
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("marketplace")]
    public required string Marketplace { get; init; }

    [JsonPropertyName("game")]
    public required string Game { get; init; }

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

    [JsonPropertyName("condition")]
    public string? Condition { get; init; }

    [JsonPropertyName("thumbnail")]
    public string? Thumbnail { get; init; }

    [JsonPropertyName("updatedAt")]
    public long UpdatedAt { get; init; }

    [JsonPropertyName("offers")]
    public required IReadOnlyList<MarketplaceOffer> Offers { get; init; }

    [JsonPropertyName("buyOrders")]
    public required IReadOnlyList<MarketplaceBuyOrder> BuyOrders { get; init; }
}