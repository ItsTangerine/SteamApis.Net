using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class RecentGame
{
    [JsonPropertyName("game")]
    public required GameMetaBase Game { get; init; }

    [JsonPropertyName("minutes")]
    public int Minutes { get; init; }

    [JsonPropertyName("recentMinutes")]
    public int RecentMinutes { get; init; }

    [JsonPropertyName("windowsMinutes")]
    public int? WindowsMinutes { get; init; }

    [JsonPropertyName("macMinutes")]
    public int? MacMinutes { get; init; }

    [JsonPropertyName("linuxMinutes")]
    public int? LinuxMinutes { get; init; }

    [JsonPropertyName("disconnectedMinutes")]
    public int DisconnectedMinutes { get; init; }
}