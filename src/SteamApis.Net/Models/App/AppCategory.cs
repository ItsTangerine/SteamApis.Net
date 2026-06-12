using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppCategory
{
    [JsonPropertyName("id")]
    public int Id { get; init; }
 
    [JsonPropertyName("description")]
    public string? Description { get; init; }
}