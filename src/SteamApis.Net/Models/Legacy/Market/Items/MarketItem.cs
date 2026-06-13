using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Items;

public class MarketItem
{
    [JsonPropertyName("nameID")]
    public required string NameId { get; init; }

    [JsonPropertyName("market_name")]
    public required string MarketName { get; init; }

    [JsonPropertyName("market_hash_name")]
    public required string MarketHashName { get; init; }

    [JsonPropertyName("border_color")]
    public required string BorderColor { get; init; }

    [JsonPropertyName("image")]
    public required string Image { get; init; }

    [JsonPropertyName("prices")]
    public required MarketItemPriceData Prices { get; init; }

    [JsonPropertyName("updated_at")]
    public long UpdatedAt { get; init; }
}