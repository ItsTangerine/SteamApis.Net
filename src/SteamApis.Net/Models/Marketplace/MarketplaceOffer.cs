using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public sealed class MarketplaceOffer
{
    [JsonPropertyName("purchaseLink")]
    public string? PurchaseLink { get; init; }

    [JsonPropertyName("inspectLink")]
    public string? InspectLink { get; init; }

    [JsonPropertyName("priceUSD")]
    public double? PriceUsd { get; init; }

    [JsonPropertyName("priceEUR")]
    public double? PriceEur { get; init; }

    [JsonPropertyName("priceCNY")]
    public double? PriceCny { get; init; }

    [JsonPropertyName("priceRUB")]
    public double? PriceRub { get; init; }

    [JsonPropertyName("float")]
    public double? Float { get; init; }

    [JsonPropertyName("paintIndex")]
    public int? PaintIndex { get; init; }

    [JsonPropertyName("paintSeed")]
    public int? PaintSeed { get; init; }

    [JsonPropertyName("daysTradeLocked")]
    public int? DaysTradeLocked { get; init; }

    [JsonPropertyName("foundAt")]
    public long FoundAt { get; init; }

    [JsonPropertyName("updatedAt")]
    public long UpdatedAt { get; init; }

    [JsonPropertyName("stickers")]
    public IReadOnlyList<JsonElement>? Stickers { get; init; }

    [JsonPropertyName("ownerId")]
    public string? OwnerId { get; init; }
}