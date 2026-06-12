using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class SteamAction
{
    [JsonPropertyName("link")]
    public required string Link { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}