using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class ItemDetails
{
    [JsonPropertyName("item")]
    public required MarketItem Item { get; init; }

    [JsonPropertyName("meta")]
    public ItemMeta? Meta { get; init; }

    [JsonPropertyName("histogram")]
    public ItemHistogram? Histogram { get; init; }

    [JsonPropertyName("priceHistory")]
    public ItemPriceHistory? PriceHistory { get; init; }
}