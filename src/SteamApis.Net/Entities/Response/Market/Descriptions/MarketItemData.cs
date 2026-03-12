using System.Text.Json.Serialization;
using SteamApis.Net.Entities.Response.Market.Common;

namespace SteamApis.Net.Entities.Response.Market.Descriptions;

public record MarketItemData
{
    [JsonPropertyName("app_icon")]
    public string AppIcon { get; init; } = default!;

    [JsonPropertyName("market_marketable_restriction")]
    public int? MarketMarketableRestriction { get; init; }

    [JsonPropertyName("market_tradable_restriction")]
    public int? MarketTradableRestriction { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("owner_actions")]
    public List<MarketItemAction> OwnerActions { get; init; } = [];

    [JsonPropertyName("actions")]
    public List<MarketItemAction> Actions { get; init; } = [];

    [JsonPropertyName("descriptions")]
    public List<MarketItemDescription> Descriptions { get; init; } = [];

    [JsonPropertyName("icon_url_large")]
    public string IconUrlLarge { get; init; } = null!;

    [JsonPropertyName("icon_url")]
    public string IconUrl { get; init; } = null!;

    [JsonPropertyName("classid")]
    public string ClassId { get; init; } = null!;

    [JsonPropertyName("contextid")]
    [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
    public int ContextId { get; init; }

    [JsonPropertyName("nameID")]
    public string NameId { get; init; } = null!;
}