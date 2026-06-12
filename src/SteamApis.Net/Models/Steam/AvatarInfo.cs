using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class AvatarInfo
{
    [JsonPropertyName("small")]
    public string? Small { get; init; }
 
    [JsonPropertyName("medium")]
    public string? Medium { get; init; }
 
    [JsonPropertyName("large")]
    public string? Large { get; init; }
 
    [JsonPropertyName("hash")]
    public string? Hash { get; init; }
}