using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppSupportInfo
{
    [JsonPropertyName("url")]
    public string? Url { get; init; }

    [JsonPropertyName("email")]
    public string? Email { get; init; }
}