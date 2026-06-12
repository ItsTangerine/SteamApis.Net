using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class Metacritic
{
    [JsonPropertyName("score")]
    public int? Score { get; init; }

    [JsonPropertyName("url")]
    public string? Url { get; init; }
}