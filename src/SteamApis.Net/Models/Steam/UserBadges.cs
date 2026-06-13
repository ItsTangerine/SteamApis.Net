using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class UserBadges
{
    [JsonPropertyName("badges")]
    public required IReadOnlyList<Badge> Badges { get; init; }

    [JsonPropertyName("xp")]
    public required int Xp { get; init; }

    [JsonPropertyName("xpRemaining")]
    public required int XpRemaining { get; init; }

    [JsonPropertyName("level")]
    public required int Level { get; init; }

    [JsonPropertyName("levelXP")]
    public required int LevelXp { get; init; }
}