using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Inventory;

public record TagEntry
{
    [JsonPropertyName("category")]
    public string Category { get; init; } = null!;

    [JsonPropertyName("internal_name")]
    public string InternalName { get; init; } = null!;

    [JsonPropertyName("localized_category_name")]
    public string LocalizedCategoryName { get; init; } = null!;

    [JsonPropertyName("localized_tag_name")]
    public string LocalizedTagName { get; init; } = null!;

    [JsonPropertyName("color")]
    public string? Color { get; init; }
}