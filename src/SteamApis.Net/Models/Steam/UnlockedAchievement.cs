using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class UnlockedAchievement
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("unlocked")]
    public bool Unlocked { get; init; }
}