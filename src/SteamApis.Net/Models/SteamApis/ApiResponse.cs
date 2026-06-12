using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.SteamApis;

/// <summary>Wire format for single-resource Steam API v2 responses.</summary>
internal sealed class ApiResponse<T>
{
    [JsonPropertyName("success")]
    public bool Success { get; init; }
 
    [JsonPropertyName("result")]
    public T? Result { get; init; }
 
    [JsonPropertyName("error")]
    public SteamApiError? Error { get; init; }
}