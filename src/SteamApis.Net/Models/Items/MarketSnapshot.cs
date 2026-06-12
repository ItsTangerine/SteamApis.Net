using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class MarketSnapshot
{
    [JsonPropertyName("metadata")]
    public required MarketSnapshotMetadata Metadata { get; init; }

    [JsonPropertyName("items")]
    public required IReadOnlyList<MarketSnapshotItem> Items { get; init; }
}