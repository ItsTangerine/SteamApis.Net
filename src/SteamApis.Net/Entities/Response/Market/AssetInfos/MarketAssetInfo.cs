using System.Text.Json.Serialization;
using SteamApis.Net.Entities.Response.Market.Common;

namespace SteamApis.Net.Entities.Response.Market.AssetInfos;

public record MarketAssetInfo
{
    [JsonPropertyName("market_hash_name")]
    public string MarketHashName { get; init; } = default!;

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    [JsonPropertyName("name_color")]
    public string? NameColor { get; init; }

    [JsonPropertyName("icon_url_large")]
    public string? IconUrlLarge { get; init; }

    [JsonPropertyName("icon_drag_url")]
    public string? IconDragUrl { get; init; }

    [JsonPropertyName("background_color")]
    public string? BackgroundColor { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("tradable")]
    public bool? Tradable { get; init; }

    [JsonPropertyName("marketable")]
    public bool? Marketable { get; init; }

    [JsonPropertyName("commodity")]
    public bool? Commodity { get; init; }

    [JsonPropertyName("descriptions")]
    public List<MarketItemDescription>? Descriptions { get; init; }

    [JsonPropertyName("actions")]
    public List<MarketItemAction>? Actions { get; init; }

    [JsonPropertyName("market_actions")]
    public List<MarketItemAction>? MarketActions { get; init; }

    [JsonPropertyName("owner_actions")]
    public List<MarketItemAction>? OwnerActions { get; init; }

    [JsonPropertyName("tags")]
    public List<MarketItemTag>? Tags { get; init; }
}