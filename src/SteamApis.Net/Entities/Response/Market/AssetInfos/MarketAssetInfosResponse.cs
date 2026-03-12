using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.AssetInfos;

public record MarketAssetInfosResponse
{
    [JsonPropertyName("total")]
    public int Total { get; init; }

    [JsonPropertyName("results")]
    public List<MarketAssetInfo> Results { get; init; } = [];
}