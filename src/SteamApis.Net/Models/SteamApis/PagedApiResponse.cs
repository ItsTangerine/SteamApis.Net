using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.SteamApis;

/// <summary>Wire format for paginated Steam API v2 responses.</summary>
public sealed class PagedApiResponse<T>
{
    [JsonPropertyName("success")]
    public bool Success { get; init; }
 
    [JsonPropertyName("results")]
    public IReadOnlyList<T>? Results { get; init; }
 
    [JsonPropertyName("cursor")]
    public string? Cursor { get; init; }
 
    [JsonPropertyName("hasMore")]
    public bool HasMore { get; init; }
}