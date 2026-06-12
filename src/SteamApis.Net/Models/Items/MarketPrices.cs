using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class MarketPrices
{
    [JsonPropertyName("recent")]
    public MarketPriceWindow? Recent { get; init; }

    [JsonPropertyName("7d")]
    public MarketPriceWindow? SevenDays { get; init; }

    [JsonPropertyName("30d")]
    public MarketPriceWindow? ThirtyDays { get; init; }

    [JsonPropertyName("90d")]
    public MarketPriceWindow? NinetyDays { get; init; }

    [JsonPropertyName("180d")]
    public MarketPriceWindow? OneHundredEightyDays { get; init; }

    [JsonPropertyName("all")]
    public MarketPriceWindow? All { get; init; }
}