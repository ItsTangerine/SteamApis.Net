using System.Text.Json.Serialization;
using SteamApis.Net.Json;

namespace SteamApis.Net.Entities.Response.Market.Items;

public record MarketItemPriceData
{
    [JsonPropertyName("latest")]
    public decimal Latest { get; init; }

    [JsonPropertyName("min")]
    public decimal Min { get; init; }

    [JsonPropertyName("avg")]
    public decimal Avg { get; init; }

    [JsonPropertyName("max")]
    public decimal Max { get; init; }

    [JsonPropertyName("mean")]
    public decimal Mean { get; init; }

    [JsonPropertyName("median")]
    public decimal Median { get; init; }

    [JsonPropertyName("safe")]
    public decimal Safe { get; init; }

    [JsonPropertyName("safe_ts")]
    public SafeTimeSeries SafeTs { get; init; } = default!;

    [JsonPropertyName("sold")]
    public SoldInfo Sold { get; init; } = default!;

    [JsonPropertyName("unstable")]
    public bool Unstable { get; init; }

    [JsonPropertyName("unstable_reason")]
    [JsonConverter(typeof(UnstableReasonConverter))]
    public UnstableReason UnstableReason { get; init; } = default!;

    [JsonPropertyName("first_seen")]
    public long FirstSeen { get; init; }
}