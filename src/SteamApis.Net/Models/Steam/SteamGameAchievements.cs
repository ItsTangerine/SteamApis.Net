using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class SteamGameAchievements
{
    [JsonPropertyName("steamID")]
    public required string SteamId { get; init; }

    [JsonPropertyName("game")]
    public required string Game { get; init; }

    [JsonPropertyName("achievements")]
    public IReadOnlyList<Achievement>? Achievements { get; init; }
}