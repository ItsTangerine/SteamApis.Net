using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class ItemOrder
{
    [JsonPropertyName("price")]
    public double Price { get; init; }

    [JsonPropertyName("quantity")]
    public long Quantity { get; init; }
}