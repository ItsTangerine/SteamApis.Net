using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class ItemTag
{
    [JsonPropertyName("internal_name")]
    public required string InternalName { get; init; }
    
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    [JsonPropertyName("category")]
    public required string Category { get; init; }
    
    [JsonPropertyName("category_name")]
    public required string CategoryName { get; init; }
    
    [JsonPropertyName("escalate_to_parent")]
    public string? EscalateToParent { get; init; }
}