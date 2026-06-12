using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public sealed class MarketplaceGameInfo
{
    [JsonPropertyName("game")]
    public required string Game { get; init; }

    [JsonPropertyName("itemCount")]
    public long ItemCount { get; init; }

    [JsonPropertyName("offerCount")]
    public long OfferCount { get; init; }

    [JsonPropertyName("salesCount")]
    public long SalesCount { get; init; }

    [JsonPropertyName("priceHistoryDays")]
    public int PriceHistoryDays { get; init; }
}