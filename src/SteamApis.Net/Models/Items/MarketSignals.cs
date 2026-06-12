using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class MarketSignals
{
    [JsonPropertyName("confidence")]
    public required string Confidence { get; init; }

    [JsonPropertyName("confidenceScore")]
    public double ConfidenceScore { get; init; }

    [JsonPropertyName("stale")]
    public bool Stale { get; init; }

    [JsonPropertyName("unstable")]
    public bool Unstable { get; init; }

    [JsonPropertyName("unstableReasons")]
    public required IReadOnlyList<string> UnstableReasons { get; init; }

    [JsonPropertyName("volatility")]
    public double? Volatility { get; init; }

    [JsonPropertyName("volatility30d")]
    public double? Volatility30Days { get; init; }

    [JsonPropertyName("liquidity")]
    public required string Liquidity { get; init; }

    [JsonPropertyName("manipulationRisk")]
    public required string ManipulationRisk { get; init; }

    [JsonPropertyName("manipulationFlags")]
    public required IReadOnlyList<string> ManipulationFlags { get; init; }

    [JsonPropertyName("priceMomentum7d")]
    public double? PriceMomentum7Days { get; init; }

    [JsonPropertyName("volumeTrend")]
    public required string VolumeTrend { get; init; }
}