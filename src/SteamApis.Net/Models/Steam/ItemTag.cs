using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class ItemTag
{
    [JsonPropertyName("category")]
    public string? Category { get; init; }
 
    [JsonPropertyName("internal_name")]
    public string? InternalName { get; init; }
 
    [JsonPropertyName("localized_category_name")]
    public string? LocalizedCategoryName { get; init; }
 
    [JsonPropertyName("localized_tag_name")]
    public string? LocalizedTagName { get; init; }
 
    [JsonPropertyName("color")]
    public string? Color { get; init; }
}