using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class SteamDescription
{
    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("value")]
    public string? Value { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }
}