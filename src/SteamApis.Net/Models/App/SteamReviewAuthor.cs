using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class SteamReviewAuthor
{
    [JsonPropertyName("steamId")]
    public required string SteamId { get; init; }

    [JsonPropertyName("playtimeAtReview")]
    public int PlaytimeAtReview { get; init; }
}