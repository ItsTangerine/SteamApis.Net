using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Item;

public record OrderEntry
{
    [JsonPropertyName("price")]
    public decimal Price { get; init; }

    [JsonPropertyName("quantity")]
    public int Quantity { get; init; }
}