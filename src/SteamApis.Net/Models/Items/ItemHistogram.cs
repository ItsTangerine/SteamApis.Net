using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class ItemHistogram
{
    [JsonPropertyName("_id")]
    public required string Id { get; init; }
    
    [JsonPropertyName("buyOrders")]
    public required IReadOnlyList<ItemOrder> BuyOrders { get; init; }

    [JsonPropertyName("sellOrders")]
    public required IReadOnlyList<ItemOrder> SellOrders { get; init; }

    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; init; }
}