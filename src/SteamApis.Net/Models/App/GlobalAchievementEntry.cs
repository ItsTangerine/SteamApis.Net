using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class GlobalAchievementEntry
{
    /// <summary>
    /// The internal identifier of the achievement.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    /// <summary>
    /// The percentage of players that have unlocked this achievement, as a string with one decimal place (for example "72.2").
    /// </summary>
    [JsonPropertyName("percent")]
    public required string Percent { get; init; }
}