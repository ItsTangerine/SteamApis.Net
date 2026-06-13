using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Steam.Vanity;

public record SteamVanityResponse
{
    [JsonPropertyName("steamid")]
    public string SteamId { get; init; } = null!;
    
    [JsonPropertyName("success")]
    public int Success { get; init; }
}