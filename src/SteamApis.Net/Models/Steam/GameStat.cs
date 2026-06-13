using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class GameStat
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("value")]
    public double Value { get; init; }
}