using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public class MarketplaceBuyOrder
{
    [JsonPropertyName("orderId")]
    public string? OrderId { get; init; }

    [JsonPropertyName("quantity")]
    public long? Quantity { get; init; }

    [JsonPropertyName("priceUSD")]
    public double? PriceUsd { get; init; }

    [JsonPropertyName("priceEUR")]
    public double? PriceEur { get; init; }

    [JsonPropertyName("priceCNY")]
    public double? PriceCny { get; init; }

    [JsonPropertyName("priceRUB")]
    public double? PriceRub { get; init; }

    [JsonPropertyName("itemPhase")]
    public string? ItemPhase { get; init; }

    [JsonPropertyName("updatedAt")]
    public long UpdatedAt { get; init; }
}