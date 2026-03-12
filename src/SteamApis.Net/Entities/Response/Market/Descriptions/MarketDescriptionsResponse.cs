using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Descriptions;

public class MarketDescriptionsResponse
{
    [JsonPropertyName("page")]
    public int Page { get; init; }

    [JsonPropertyName("pages")]
    public int Pages { get; init; }

    [JsonPropertyName("data")]
    public List<MarketItemData> Data { get; init; } = [];
}