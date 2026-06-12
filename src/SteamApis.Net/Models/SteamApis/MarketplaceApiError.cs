using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.SteamApis;

/// <summary>Wire-level error from the flat Marketplace API.</summary>
internal sealed class MarketplaceApiError
{
    [JsonPropertyName("error")]
    public string? Error { get; init; }
 
    [JsonPropertyName("code")]
    public string? Code { get; init; }
}