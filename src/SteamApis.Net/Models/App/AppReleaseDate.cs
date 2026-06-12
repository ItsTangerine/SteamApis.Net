using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppReleaseDate
{
    [JsonPropertyName("comingSoon")]
    public bool ComingSoon { get; init; }
 
    [JsonPropertyName("date")]
    public string? Date { get; init; }
}