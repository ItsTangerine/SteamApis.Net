using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class GameStat
{
    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("value")]
    public double Value { get; init; }
}