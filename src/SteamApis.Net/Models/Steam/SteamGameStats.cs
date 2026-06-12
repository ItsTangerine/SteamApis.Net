using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class SteamGameStats
{
    [JsonPropertyName("steamID")]
    public required string SteamId { get; init; } 

    [JsonPropertyName("game")]
    public required string Game { get; init; }

    [JsonPropertyName("achievements")]
    public IReadOnlyList<UnlockedAchievement> Achievements { get; init; } = [];

    [JsonPropertyName("stats")]
    public IReadOnlyList<GameStat> Stats { get; init; } = [];
}