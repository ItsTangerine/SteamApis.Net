using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class UserGame
{
    [JsonPropertyName("game")]
    public required GameMeta Game { get; init; }

    [JsonPropertyName("minutes")]
    public int Minutes { get; init; }

    [JsonPropertyName("recentMinutes")]
    public int RecentMinutes { get; init; }

    [JsonPropertyName("disconnectedMinutes")]
    public int DisconnectedMinutes { get; init; }
}