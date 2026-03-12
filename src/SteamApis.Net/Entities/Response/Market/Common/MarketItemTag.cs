using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Common;

public record MarketItemTag
{
    [JsonPropertyName("category")]
    public string Category { get; init; } = null!;

    [JsonPropertyName("internal_name")]
    public string InternalName { get; init; } = null!;

    [JsonPropertyName("category_name")]
    public string CategoryName { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;
}