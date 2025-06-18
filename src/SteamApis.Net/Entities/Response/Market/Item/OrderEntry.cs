using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Item;

public record OrderEntry
{
    [JsonPropertyName("price")]
    public decimal Price { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }
}