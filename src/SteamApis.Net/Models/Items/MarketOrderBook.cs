using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class MarketOrderBook
{
    [JsonPropertyName("highestBuy")]
    public double HighestBuy { get; init; }

    [JsonPropertyName("lowestSell")]
    public double LowestSell { get; init; }

    [JsonPropertyName("spread")]
    public double Spread { get; init; }

    [JsonPropertyName("spreadPct")]
    public double SpreadPct { get; init; }

    [JsonPropertyName("buyDepth")]
    public long BuyDepth { get; init; }

    [JsonPropertyName("sellDepth")]
    public long SellDepth { get; init; }

    [JsonPropertyName("buyOrdersTop10")]
    public required IReadOnlyList<MarketOrderLevel> BuyOrdersTop10 { get; init; }

    [JsonPropertyName("sellOrdersTop10")]
    public required IReadOnlyList<MarketOrderLevel> SellOrdersTop10 { get; init; }

    [JsonPropertyName("imbalanceRatio")]
    public double? ImbalanceRatio { get; init; }

    [JsonPropertyName("histogramAgeSeconds")]
    public long HistogramAgeSeconds { get; init; }
}