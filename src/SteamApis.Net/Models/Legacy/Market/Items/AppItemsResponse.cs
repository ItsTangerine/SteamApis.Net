using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Items;

public record AppItemsResponse
{
    [JsonPropertyName("appID")]
    public int AppId { get; init; }

    [JsonPropertyName("data")]
    public IReadOnlyList<MarketItem> Data { get; init; } = [];
}