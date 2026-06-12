using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public sealed class MarketplacePrice
{
    [JsonPropertyName("marketplace")]
    public string? Marketplace { get; init; }
 
    [JsonPropertyName("price")]
    public double? Price { get; init; }
 
    [JsonPropertyName("currency")]
    public string? Currency { get; init; }
 
    [JsonPropertyName("url")]
    public string? Url { get; init; }
}