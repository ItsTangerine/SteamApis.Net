using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Summary;

public record SteamBadge
{
    [JsonPropertyName("badgeid")]
    public int BadgeId { get; init; }

    [JsonPropertyName("appid")]
    public int? AppId { get; init; }

    [JsonPropertyName("level")]
    public int Level { get; init; }

    [JsonPropertyName("completion_time")]
    public long CompletionTime { get; init; }

    [JsonPropertyName("xp")]
    public int Xp { get; init; }

    [JsonPropertyName("communityitemid")]
    public string? CommunityItemId { get; init; }

    [JsonPropertyName("border_color")]
    public int? BorderColor { get; init; }

    [JsonPropertyName("scarcity")]
    public int Scarcity { get; init; }
}