using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class UnlockedAchievement
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("unlocked")]
    public bool Unlocked { get; init; }
}