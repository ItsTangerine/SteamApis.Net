using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Inventory;

public record DescriptionEntry
{
    [JsonPropertyName("type")]
    public string Type { get; init; } = null!;

    [JsonPropertyName("value")]
    public string Value { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("color")]
    public string? Color { get; init; }
}