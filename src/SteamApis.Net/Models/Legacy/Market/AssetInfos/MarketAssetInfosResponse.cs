using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.AssetInfos;

public record MarketAssetInfosResponse
{
    [JsonPropertyName("total")]
    public int Total { get; init; }

    [JsonPropertyName("results")]
    public List<MarketAssetInfo> Results { get; init; } = [];
}