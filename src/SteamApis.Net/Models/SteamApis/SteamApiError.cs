using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.SteamApis;

/// <summary>Wire-level error object from the Steam API envelope.</summary>
internal sealed class SteamApiError
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }
 
    [JsonPropertyName("message")]
    public string? Message { get; init; }
 
    [JsonPropertyName("meta")]
    public object? Meta { get; init; }
}