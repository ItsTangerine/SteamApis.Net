using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Vanity;

public record SteamVanityResponse
{
    [JsonPropertyName("steamid")]
    public string SteamId { get; init; } = null!;
    
    [JsonPropertyName("success")]
    public int Success { get; init; }
}