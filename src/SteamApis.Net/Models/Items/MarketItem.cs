using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class MarketItem
{
    [JsonPropertyName("_id")]
    public required string Id { get; init; }

    [JsonPropertyName("nameId")]
    public long? NameId { get; init; }

    [JsonPropertyName("appId")]
    public int AppId { get; init; }

    [JsonPropertyName("marketName")]
    public required string MarketName { get; init; }

    [JsonPropertyName("marketHashName")]
    public required string MarketHashName { get; init; }

    [JsonPropertyName("classId")]
    public long? ClassId { get; init; }

    [JsonPropertyName("instanceId")]
    public long? InstanceId { get; init; }

    [JsonPropertyName("isGlitched")]
    public bool IsGlitched { get; init; }

    [JsonPropertyName("metaUpdatedAt")]
    public DateTimeOffset? MetaUpdatedAt { get; init; }

    [JsonPropertyName("histogramUpdatedAt")]
    public DateTimeOffset? HistogramUpdatedAt { get; init; }

    [JsonPropertyName("priceHistoryUpdatedAt")]
    public DateTimeOffset? PriceHistoryUpdatedAt { get; init; }
}