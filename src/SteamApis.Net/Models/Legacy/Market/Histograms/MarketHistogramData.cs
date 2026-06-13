using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Histograms;

public record MarketHistogramData
{
    [JsonPropertyName("market_hash_name")]
    public string MarketHashName { get; init; } = null!;

    [JsonPropertyName("histogram")]
    public MarketItemHistogram Histogram { get; init; } = null!;
}