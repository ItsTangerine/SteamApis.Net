using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class SteamUser
{
    [JsonPropertyName("steamID")]
    public string SteamId { get; init; } = string.Empty;
 
    [JsonPropertyName("avatar")]
    public AvatarInfo? Avatar { get; init; }
 
    [JsonPropertyName("url")]
    public string? Url { get; init; }
 
    [JsonPropertyName("visible")]
    public bool Visible { get; init; }
 
    /// <summary>0=Offline 1=Online 2=Busy 3=Away 4=Snooze 5=LookingToTrade 6=LookingToPlay</summary>
    [JsonPropertyName("personaState")]
    public int PersonaState { get; init; }
 
    [JsonPropertyName("personaStateFlags")]
    public int PersonaStateFlags { get; init; }
 
    [JsonPropertyName("allowsComments")]
    public bool AllowsComments { get; init; }
 
    [JsonPropertyName("nickname")]
    public string? Nickname { get; init; }
 
    [JsonPropertyName("lastLogOffTimestamp")]
    public long LastLogOffTimestamp { get; init; }
 
    [JsonPropertyName("createdTimestamp")]
    public long CreatedTimestamp { get; init; }
 
    [JsonPropertyName("primaryGroupID")]
    public string? PrimaryGroupId { get; init; }
 
    [JsonPropertyName("countryCode")]
    public string? CountryCode { get; init; }
}