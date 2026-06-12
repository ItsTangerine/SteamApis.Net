using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppNews
{
    [JsonPropertyName("id")]
    public required string Id { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("url")]
    public required string Url { get; init; }

    [JsonPropertyName("urlExternal")]
    public bool UrlExternal { get; init; }

    [JsonPropertyName("author")]
    public required string Author { get; init; }

    [JsonPropertyName("content")]
    public required string Content { get; init; }

    [JsonPropertyName("publishedTimestamp")]
    public long PublishedTimestamp { get; init; }

    [JsonPropertyName("feed")]
    public required string Feed { get; init; }

    [JsonPropertyName("feedName")]
    public required string FeedName { get; init; }

    [JsonPropertyName("feedType")]
    public int FeedType { get; init; }

    [JsonPropertyName("appID")]
    public int AppId { get; init; }

    [JsonPropertyName("tags")]
    public IReadOnlyList<string>? Tags { get; init; }
}