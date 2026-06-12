using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class UserBadges
{
    [JsonPropertyName("playerXp")]
    public long PlayerXp { get; init; }
 
    [JsonPropertyName("playerLevel")]
    public int PlayerLevel { get; init; }
 
    [JsonPropertyName("xpNeededToLevelUp")]
    public long XpNeededToLevelUp { get; init; }
 
    [JsonPropertyName("xpNeededCurrentLevel")]
    public long XpNeededCurrentLevel { get; init; }
 
    [JsonPropertyName("badges")]
    public IReadOnlyList<Badge>? Badges { get; init; }
}