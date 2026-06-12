using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class ItemDescription
{
    [JsonPropertyName("appid")]
    public int AppId { get; init; }

    [JsonPropertyName("classid")]
    public required string ClassId { get; init; }

    [JsonPropertyName("instanceid")]
    public required string InstanceId { get; init; }

    [JsonPropertyName("currency")]
    public int Currency { get; init; }

    [JsonPropertyName("background_color")]
    public required string BackgroundColor { get; init; }

    [JsonPropertyName("icon_url")]
    public required string IconUrl { get; init; }

    [JsonPropertyName("descriptions")]
    public IReadOnlyList<SteamDescription>? Descriptions { get; init; }

    [JsonPropertyName("tradable")]
    public int Tradable { get; init; }

    [JsonPropertyName("actions")]
    public IReadOnlyList<SteamAction>? Actions { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("name_color")]
    public required string NameColor { get; init; }

    [JsonPropertyName("type")]
    public required string Type { get; init; }

    [JsonPropertyName("market_name")]
    public required string MarketName { get; init; }

    [JsonPropertyName("market_hash_name")]
    public required string MarketHashName { get; init; }

    [JsonPropertyName("market_actions")]
    public IReadOnlyList<SteamAction>? MarketActions { get; init; }

    [JsonPropertyName("commodity")]
    public int Commodity { get; init; }

    [JsonPropertyName("market_tradable_restriction")]
    public int MarketTradableRestriction { get; init; }

    [JsonPropertyName("market_marketable_restriction")]
    public int MarketMarketableRestriction { get; init; }

    [JsonPropertyName("marketable")]
    public int Marketable { get; init; }

    [JsonPropertyName("tags")]
    public IReadOnlyList<ItemTag>? Tags { get; init; }

    [JsonPropertyName("sealed")]
    public int Sealed { get; init; }

    [JsonPropertyName("market_bucket_group_name")]
    public required string MarketBucketGroupName { get; init; }

    [JsonPropertyName("market_bucket_group_id")]
    public required string MarketBucketGroupId { get; init; }

    [JsonPropertyName("sealed_type")]
    public int SealedType { get; init; }

    [JsonPropertyName("market_name_inside_group")]
    public required string MarketNameInsideGroup { get; init; }
 
    /// <summary>Builds the full CDN URL from the relative icon_url.</summary>
    public string GetIconFullUrl() => $"https://community.cloudflare.steamstatic.com/economy/image/{IconUrl}";
}