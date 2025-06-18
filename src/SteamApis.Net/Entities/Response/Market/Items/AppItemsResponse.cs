using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Items;

public record AppItemsResponse
{
    [JsonPropertyName("appID")]
    public int AppId { get; init; }

    [JsonPropertyName("data")]
    public List<MarketItem> Data { get; init; } = [];
}