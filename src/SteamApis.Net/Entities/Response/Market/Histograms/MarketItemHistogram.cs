using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Histograms;

public record MarketItemHistogram
{
    [JsonPropertyName("highest_buy_order")]
    public decimal? HighestBuyOrder { get; init; }

    [JsonPropertyName("lowest_sell_order")]
    public decimal? LowestSellOrder { get; init; }
}