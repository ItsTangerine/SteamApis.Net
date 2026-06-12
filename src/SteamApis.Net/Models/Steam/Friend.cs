using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class Friend
{
    [JsonPropertyName("steamID")]
    public string SteamId { get; init; } = string.Empty;
 
    [JsonPropertyName("relationship")]
    public string? Relationship { get; init; }
 
    [JsonPropertyName("friendSince")]
    public long FriendSince { get; init; }
}