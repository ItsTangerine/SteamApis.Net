using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Item;

public record MarketAssetInfo
{
    [JsonPropertyName("name_color")]
    public string NameColor { get; init; } = default!;

    [JsonPropertyName("background_color")]
    public string BackgroundColor { get; init; } = default!;

    [JsonPropertyName("type")]
    public string Type { get; init; } = default!;

    [JsonPropertyName("tradable")]
    public bool Tradable { get; init; }

    [JsonPropertyName("marketable")]
    public bool Marketable { get; init; }

    [JsonPropertyName("commodity")]
    public bool Commodity { get; init; }

    [JsonPropertyName("descriptions")]
    public List<AssetDescription> Descriptions { get; init; } = default!;

    [JsonPropertyName("actions")]
    public List<ActionEntry> Actions { get; init; } = default!;

    [JsonPropertyName("market_actions")]
    public List<ActionEntry> MarketActions { get; init; } = default!;

    [JsonPropertyName("owner_actions")]
    public List<ActionEntry> OwnerActions { get; init; } = default!;

    [JsonPropertyName("tags")]
    public List<MarketTag> Tags { get; init; } = default!;

    [JsonPropertyName("market_tradable_restriction")]
    public int MarketTradableRestriction { get; init; }
}