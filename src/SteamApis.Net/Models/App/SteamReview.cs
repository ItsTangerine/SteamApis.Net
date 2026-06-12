using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class SteamReview
{
    [JsonPropertyName("_id")]
    public required string Id { get; init; }

    [JsonPropertyName("recommendationId")]
    public required string RecommendationId { get; init; }

    [JsonPropertyName("appId")]
    public int AppId { get; init; }

    [JsonPropertyName("author")]
    public required SteamReviewAuthor Author { get; init; }

    [JsonPropertyName("commentCount")]
    public int CommentCount { get; init; }

    [JsonPropertyName("language")]
    public required string Language { get; init; }

    [JsonPropertyName("receivedForFree")]
    public bool ReceivedForFree { get; init; }

    [JsonPropertyName("review")]
    public required string Review { get; init; }

    [JsonPropertyName("steamPurchase")]
    public bool SteamPurchase { get; init; }

    [JsonPropertyName("timestampCreated")]
    public long TimestampCreated { get; init; }

    [JsonPropertyName("timestampUpdated")]
    public long TimestampUpdated { get; init; }

    [JsonPropertyName("votedUp")]
    public bool VotedUp { get; init; }

    [JsonPropertyName("votesFunny")]
    public int VotesFunny { get; init; }

    [JsonPropertyName("votesUp")]
    public int VotesUp { get; init; }

    [JsonPropertyName("weightedVoteScore")]
    public required string WeightedVoteScore { get; init; }

    [JsonPropertyName("writtenDuringEarlyAccess")]
    public bool WrittenDuringEarlyAccess { get; init; }
}