using System.Text.Json.Serialization;
using SteamApis.Net.Json;

namespace SteamApis.Net.Entities.Response.Steam.Profile;

public record SteamProfileResponse
{
    [JsonPropertyName("steamID")]
    public SteamId SteamId { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("onlineState")]
    public OnlineState OnlineState { get; init; }

    [JsonPropertyName("stateMessage")]
    public string StateMessage { get; init; } = null!;

    [JsonPropertyName("privacyState")]
    public string PrivacyState { get; init; } = null!;

    [JsonPropertyName("visibilityState")]
    public string VisibilityState { get; init; } = null!;

    [JsonPropertyName("avatarHash")]
    public string AvatarHash { get; init; } = null!;

    [JsonPropertyName("vacBanned")]
    public bool VacBanned { get; init; }

    [JsonPropertyName("tradeBanState")]
    public string TradeBanState { get; init; } = null!;

    [JsonPropertyName("isLimitedAccount")]
    public bool IsLimitedAccount { get; init; }

    [JsonPropertyName("customURL")]
    public string? CustomUrl { get; init; }

    [JsonPropertyName("memberSince")]
    public DateTime MemberSince { get; init; }

    [JsonPropertyName("location")]
    public string? Location { get; init; }

    [JsonPropertyName("realName")]
    public string? RealName { get; init; }

    [JsonPropertyName("summary")]
    public string Summary { get; init; } = null!;

    [JsonPropertyName("groups")]
    public List<SteamId> Groups { get; init; } = [];

    [JsonPropertyName("primaryGroup")]
    public SteamId PrimaryGroup { get; init; } = null!;

    [JsonPropertyName("contexts")]
    public Dictionary<string, AppContext> Contexts { get; init; } = [];
}