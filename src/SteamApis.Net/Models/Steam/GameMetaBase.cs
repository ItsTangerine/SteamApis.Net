using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public class GameMetaBase
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("icon")]
    public required string Icon { get; init; }
}