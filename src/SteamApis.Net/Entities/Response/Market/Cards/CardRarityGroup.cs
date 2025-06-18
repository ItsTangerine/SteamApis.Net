using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Cards;

public record CardRarityGroup
{
    [JsonPropertyName("count")]
    public int Count { get; init; }

    [JsonPropertyName("price")]
    public decimal Price { get; init; }

    [JsonPropertyName("avg")]
    public decimal Avg { get; init; }

    [JsonPropertyName("names")]
    public List<string> Names { get; init; } = [];
}