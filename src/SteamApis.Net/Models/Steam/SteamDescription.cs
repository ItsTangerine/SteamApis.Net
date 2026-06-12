using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class SteamDescription
{
    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("value")]
    public required string Value { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}