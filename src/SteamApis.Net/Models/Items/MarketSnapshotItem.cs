using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class MarketSnapshotItem
{
    [JsonPropertyName("nameId")]
    public long NameId { get; init; }

    [JsonPropertyName("marketName")]
    public required string MarketName { get; init; }

    [JsonPropertyName("marketHashName")]
    public required string MarketHashName { get; init; }

    [JsonPropertyName("firstSeen")]
    public long? FirstSeen { get; init; }

    [JsonPropertyName("lastSale")]
    public long? LastSale { get; init; }

    [JsonPropertyName("prices")]
    public required MarketPrices Prices { get; init; }

    [JsonPropertyName("volume")]
    public required MarketVolume Volume { get; init; }

    [JsonPropertyName("orderBook")]
    public required MarketOrderBook OrderBook { get; init; }

    [JsonPropertyName("signals")]
    public required MarketSignals Signals { get; init; }

    [JsonPropertyName("flags")]
    public required ItemFlags Flags { get; init; }

    [JsonPropertyName("updatedAt")]
    public long UpdatedAt { get; init; }
}