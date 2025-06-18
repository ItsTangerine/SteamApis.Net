using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Item;

public record MarketHistogram
{
    [JsonPropertyName("sell_order_array")]
    public List<OrderEntry> SellOrderArray { get; init; } = default!;

    [JsonPropertyName("sell_order_summary")]
    public OrderSummary SellOrderSummary { get; init; } = default!;

    [JsonPropertyName("buy_order_array")]
    public List<OrderEntry> BuyOrderArray { get; init; } = default!;

    [JsonPropertyName("buy_order_summary")]
    public OrderSummary BuyOrderSummary { get; init; } = default!;

    [JsonPropertyName("highest_buy_order")]
    public decimal HighestBuyOrder { get; init; }

    [JsonPropertyName("lowest_sell_order")]
    public decimal LowestSellOrder { get; init; }

    [JsonPropertyName("buy_order_graph")]
    public List<List<JsonElement>> BuyOrderGraph { get; init; } = default!;

    [JsonPropertyName("graph_max_y")]
    public decimal GraphMaxY { get; init; }

    [JsonPropertyName("graph_min_x")]
    public decimal GraphMinX { get; init; }

    [JsonPropertyName("graph_max_x")]
    public decimal GraphMaxX { get; init; }

    [JsonPropertyName("price_prefix")]
    public string PricePrefix { get; init; } = default!;

    [JsonPropertyName("price_suffix")]
    public string PriceSuffix { get; init; } = default!;

    [JsonPropertyName("updatedAt")]
    public long UpdatedAt { get; init; }
}