using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class Badge
{
    [JsonPropertyName("id")]
    public required int Id { get; init; }

    [JsonPropertyName("level")]
    public required int Level { get; init; }

    [JsonPropertyName("completedTimestamp")]
    public required long CompletedTimestamp { get; init; }

    [JsonPropertyName("xp")]
    public required int Xp { get; init; }

    [JsonPropertyName("scarcity")]
    public required int Scarcity { get; init; }

    [JsonPropertyName("appID")]
    public int? AppId { get; init; }

    [JsonPropertyName("communityItemID")]
    public string? CommunityItemId { get; init; }

    [JsonPropertyName("borderColor")]
    public int? BorderColor { get; init; }
}