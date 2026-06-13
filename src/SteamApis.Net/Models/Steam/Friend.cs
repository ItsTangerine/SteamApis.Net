using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class Friend
{
    [JsonPropertyName("steamID")]
    public required string SteamId { get; init; }
 
    [JsonPropertyName("friendedTimestamp")]
    public long FriendSince { get; init; }
    
    [JsonPropertyName("relationship")]
    public string? Relationship { get; init; }
 
}