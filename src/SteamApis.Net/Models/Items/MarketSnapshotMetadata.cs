using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class MarketSnapshotMetadata
{
    [JsonPropertyName("appId")]
    public int AppId { get; init; }

    [JsonPropertyName("itemCount")]
    public int ItemCount { get; init; }

    [JsonPropertyName("generatedAt")]
    public long GeneratedAt { get; init; }

    [JsonPropertyName("version")]
    public int Version { get; init; }
}