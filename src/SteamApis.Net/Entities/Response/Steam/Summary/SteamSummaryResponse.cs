using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Summary;

public record SteamSummaryResponse
{
    [JsonPropertyName("steamid")]
    public string SteamId { get; init; } = null!;

    [JsonPropertyName("communityvisibilitystate")]
    public int CommunityVisibilityState { get; init; }

    [JsonPropertyName("profilestate")]
    public int ProfileState { get; init; }

    [JsonPropertyName("personaname")]
    public string PersonaName { get; init; } = null!;

    [JsonPropertyName("commentpermission")]
    public int CommentPermission { get; init; }

    [JsonPropertyName("profileurl")]
    public string ProfileUrl { get; init; } = null!;

    [JsonPropertyName("avatar")]
    public string Avatar { get; init; } = null!;

    [JsonPropertyName("avatarmedium")]
    public string AvatarMedium { get; init; } = null!;

    [JsonPropertyName("avatarfull")]
    public string AvatarFull { get; init; } = null!;

    [JsonPropertyName("avatarhash")]
    public string AvatarHash { get; init; } = null!;

    [JsonPropertyName("personastate")]
    public int PersonaState { get; init; }

    [JsonPropertyName("primaryclanid")]
    public string PrimaryClanId { get; init; } = null!;

    [JsonPropertyName("timecreated")]
    public long TimeCreated { get; init; }

    [JsonPropertyName("personastateflags")]
    public int PersonaStateFlags { get; init; }

    [JsonPropertyName("loccountrycode")]
    public string? LocCountryCode { get; init; }

    [JsonPropertyName("badges")]
    public List<SteamBadge> Badges { get; init; } = [];
}