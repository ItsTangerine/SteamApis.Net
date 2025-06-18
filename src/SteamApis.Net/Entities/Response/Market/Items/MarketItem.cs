using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Items;

public class MarketItem
{
    [JsonPropertyName("nameID")]
    public string NameId { get; init; } = default!;

    [JsonPropertyName("market_name")]
    public string MarketName { get; init; } = default!;

    [JsonPropertyName("market_hash_name")]
    public string MarketHashName { get; init; } = default!;

    [JsonPropertyName("border_color")]
    public string BorderColor { get; init; } = default!;

    [JsonPropertyName("image")]
    public string Image { get; init; } = default!;

    [JsonPropertyName("prices")]
    public MarketItemPriceData Prices { get; init; } = default!;

    [JsonPropertyName("updated_at")]
    public long UpdatedAt { get; init; }
}