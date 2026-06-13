using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class UserBans
{
    [JsonPropertyName("steamID")]
    public required string SteamId { get; init; }
 
    [JsonPropertyName("communityBanned")]
    public bool CommunityBanned { get; init; }
 
    [JsonPropertyName("vacBanned")]
    public bool VacBanned { get; init; }
 
    [JsonPropertyName("vacBans")]
    public int NumberOfVacBans { get; init; }
 
    [JsonPropertyName("gameBans")]
    public int NumberOfGameBans { get; init; }
    
    [JsonPropertyName("economyBan")]
    public string? EconomyBan { get; init; }
    
    [JsonPropertyName("daysSinceLastBan")]
    public int DaysSinceLastBan { get; init; }
}