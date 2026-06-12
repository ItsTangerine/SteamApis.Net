using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class SteamApp
{
    [JsonPropertyName("appid")]
    public int AppId { get; init; }
 
    [JsonPropertyName("name")]
    public string? Name { get; init; }
}