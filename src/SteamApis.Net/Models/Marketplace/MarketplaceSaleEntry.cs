using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public sealed class MarketplaceSaleEntry
{
    [JsonPropertyName("timestamp")]
    public long Timestamp { get; init; }

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

    [JsonPropertyName("stickers")]
    public IReadOnlyList<JsonElement>? Stickers { get; init; }

    [JsonPropertyName("rarity")]
    public string? Rarity { get; init; }

    [JsonPropertyName("hero")]
    public string? Hero { get; init; }
}