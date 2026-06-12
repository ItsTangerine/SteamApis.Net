using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class ItemPricePoint
{
    [JsonPropertyName("price")]
    public double Price { get; init; }

    [JsonPropertyName("quantity")]
    public long Quantity { get; init; }

    [JsonPropertyName("date")]
    public DateTimeOffset Date { get; init; }
}