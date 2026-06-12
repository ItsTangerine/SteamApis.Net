using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class SteamGameAchievements
{
    [JsonPropertyName("steamID")]
    public string SteamId { get; init; } = default!;

    [JsonPropertyName("game")]
    public string Game { get; init; } = default!;

    [JsonPropertyName("achievements")]
    public IReadOnlyList<Achievement> Achievements { get; init; } = [];
}