using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public sealed class MarketOffer
{
    [JsonPropertyName("marketplace")]
    public string? Marketplace { get; init; }
 
    [JsonPropertyName("price")]
    public double Price { get; init; }
 
    [JsonPropertyName("currency")]
    public string? Currency { get; init; }
 
    [JsonPropertyName("count")]
    public int Count { get; init; }
 
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}