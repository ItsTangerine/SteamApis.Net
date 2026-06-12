using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class MarketVolume
{
    [JsonPropertyName("recent")]
    public long Recent { get; init; }

    [JsonPropertyName("7d")]
    public long SevenDays { get; init; }

    [JsonPropertyName("30d")]
    public long ThirtyDays { get; init; }

    [JsonPropertyName("90d")]
    public long NinetyDays { get; init; }

    [JsonPropertyName("180d")]
    public long OneHundredEightyDays { get; init; }

    [JsonPropertyName("all")]
    public long All { get; init; }
}