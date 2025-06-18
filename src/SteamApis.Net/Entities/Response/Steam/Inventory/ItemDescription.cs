using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Inventory;

public record ItemDescription
{
    [JsonPropertyName("appid")]
    public int AppId { get; init; }

    [JsonPropertyName("classid")]
    public string ClassId { get; init; } = null!;

    [JsonPropertyName("instanceid")]
    public string InstanceId { get; init; } = null!;

    [JsonPropertyName("currency")]
    public int Currency { get; init; }

    [JsonPropertyName("background_color")]
    public string? BackgroundColor { get; init; }

    [JsonPropertyName("icon_url")]
    public string? IconUrl { get; init; }

    [JsonPropertyName("descriptions")]
    public List<DescriptionEntry>? Descriptions { get; init; }

    [JsonPropertyName("tradable")]
    public int Tradable { get; init; }

    [JsonPropertyName("actions")]
    public List<ActionEntry>? Actions { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("name_color")]
    public string? NameColor { get; init; }

    [JsonPropertyName("type")]
    public string Type { get; init; } = null!;

    [JsonPropertyName("market_name")]
    public string MarketName { get; init; } = null!;

    [JsonPropertyName("market_hash_name")]
    public string MarketHashName { get; init; } = null!;

    [JsonPropertyName("market_actions")]
    public List<ActionEntry>? MarketActions { get; init; }

    [JsonPropertyName("commodity")]
    public int Commodity { get; init; }

    [JsonPropertyName("market_tradable_restriction")]
    public int MarketTradableRestriction { get; init; }

    [JsonPropertyName("market_marketable_restriction")]
    public int MarketMarketableRestriction { get; init; }

    [JsonPropertyName("marketable")]
    public int Marketable { get; init; }

    [JsonPropertyName("tags")]
    public List<TagEntry>? Tags { get; init; }
}