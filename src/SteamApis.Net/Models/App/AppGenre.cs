using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppGenre
{
    [JsonPropertyName("id")]
    public string? Id { get; init; }
 
    [JsonPropertyName("description")]
    public string? Description { get; init; }
}