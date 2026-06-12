using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class MarketPriceWindow
{
    [JsonPropertyName("min")]
    public double? Min { get; init; }

    [JsonPropertyName("max")]
    public double? Max { get; init; }

    [JsonPropertyName("median")]
    public double? Median { get; init; }

    [JsonPropertyName("safe")]
    public double? Safe { get; init; }

    [JsonPropertyName("ewma")]
    public double? Ewma { get; init; }

    [JsonPropertyName("avg")]
    public double? Avg { get; init; }

    [JsonPropertyName("latest")]
    public double? Latest { get; init; }
}