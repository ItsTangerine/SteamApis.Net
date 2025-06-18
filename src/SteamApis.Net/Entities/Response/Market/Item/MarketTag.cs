using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Item;

public record MarketTag
{
    [JsonPropertyName("internal_name")]
    public string InternalName { get; init; } = default!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("category")]
    public string Category { get; init; } = default!;

    [JsonPropertyName("category_name")]
    public string CategoryName { get; init; } = default!;
}