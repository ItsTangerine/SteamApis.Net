using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class SupportedPlatforms
{
    [JsonPropertyName("windows")]
    public bool Windows { get; init; }

    [JsonPropertyName("mac")]
    public bool Mac { get; init; }

    [JsonPropertyName("linux")]
    public bool Linux { get; init; }
}