using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class UserBans
{
    [JsonPropertyName("steamID")]
    public string SteamId { get; init; } = string.Empty;
 
    [JsonPropertyName("communityBanned")]
    public bool CommunityBanned { get; init; }
 
    [JsonPropertyName("vacBanned")]
    public bool VacBanned { get; init; }
 
    [JsonPropertyName("numberOfVacBans")]
    public int NumberOfVacBans { get; init; }
 
    [JsonPropertyName("daysSinceLastBan")]
    public int DaysSinceLastBan { get; init; }
 
    [JsonPropertyName("numberOfGameBans")]
    public int NumberOfGameBans { get; init; }
 
    [JsonPropertyName("economyBan")]
    public string? EconomyBan { get; init; }
}