using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class GameStats
{
    [JsonPropertyName("stats")]
    public required IReadOnlyList<GameStatDefinition> Stats { get; init; }

    [JsonPropertyName("achievements")]
    public IReadOnlyList<GameAchievementDefinition>? Achievements { get; init; }
}