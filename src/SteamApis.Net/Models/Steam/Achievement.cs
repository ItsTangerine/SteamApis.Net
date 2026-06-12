using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class Achievement
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("unlocked")]
    public bool Unlocked { get; init; }

    [JsonPropertyName("unlockedTimestamp")]
    public long UnlockedTimestamp { get; init; }
}