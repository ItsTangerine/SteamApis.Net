using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Item;

public record MarketAssets
{
    [JsonPropertyName("descriptions")]
    public List<AssetDescription> Descriptions { get; init; } = default!;

    [JsonPropertyName("actions")]
    public List<ActionEntry> Actions { get; init; } = default!;

    [JsonPropertyName("type")]
    public string Type { get; init; } = default!;
}