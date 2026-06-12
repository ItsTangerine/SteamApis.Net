using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class SteamGameSchema
{
    [JsonPropertyName("gameName")]
    public required string GameName { get; init; }

    [JsonPropertyName("gameVersion")]
    public required string GameVersion { get; init; }

    [JsonPropertyName("availableGameStats")]
    public required GameStats AvailableGameStats { get; init; }
}