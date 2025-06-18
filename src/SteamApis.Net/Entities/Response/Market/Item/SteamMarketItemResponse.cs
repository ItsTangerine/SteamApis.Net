using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Item;

public record SteamMarketItemResponse
{
    [JsonPropertyName("nameID")]
    public long NameId { get; init; }

    [JsonPropertyName("appID")]
    public int AppId { get; init; }

    [JsonPropertyName("market_name")]
    public string MarketName { get; init; } = default!;

    [JsonPropertyName("market_hash_name")]
    public string MarketHashName { get; init; } = default!;

    [JsonPropertyName("description")]
    public string Description { get; init; } = default!;

    [JsonPropertyName("url")]
    public string Url { get; init; } = default!;

    [JsonPropertyName("image")]
    public string Image { get; init; } = default!;

    [JsonPropertyName("border_color")]
    public string BorderColor { get; init; } = default!;

    [JsonPropertyName("app_context_data")]
    public Dictionary<string, AppContextData> AppContextData { get; init; } = default!;

    [JsonPropertyName("median_avg_prices_15days")]
    public List<List<JsonElement>> MedianAvgPrices15Days { get; init; } = default!;

    [JsonPropertyName("histogram")]
    public MarketHistogram Histogram { get; init; } = default!;

    [JsonPropertyName("assets")]
    public MarketAssets Assets { get; init; } = default!;

    [JsonPropertyName("assetInfo")]
    public MarketAssetInfo AssetInfo { get; init; } = default!;

    [JsonPropertyName("updated_at")]
    public long UpdatedAt { get; init; }
}