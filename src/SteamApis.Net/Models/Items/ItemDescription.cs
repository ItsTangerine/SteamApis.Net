using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class ItemDescription
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("value")]
    public required string Value { get; init; }

    [JsonPropertyName("color")]
    public string? Color { get; init; }
}