using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class PlayerCounts
{
    [JsonPropertyName("player_count")]
    public int PlayerCount { get; init; }
 
    [JsonPropertyName("result")]
    public int Result { get; init; }
}