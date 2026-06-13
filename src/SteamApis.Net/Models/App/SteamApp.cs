using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class SteamApp
{
    [JsonPropertyName("_id")]
    public required string Id { get; init; }

    [JsonPropertyName("appId")]
    public required long AppId { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("lastModified")]
    public long? LastModified { get; init; }

    [JsonPropertyName("priceChangeNumber")]
    public long? PriceChangeNumber { get; init; }

    [JsonPropertyName("detailsUpdatedAt")]
    public DateTimeOffset? DetailsUpdatedAt { get; init; }

    [JsonPropertyName("isActive")]
    public required bool IsActive { get; init; }
}