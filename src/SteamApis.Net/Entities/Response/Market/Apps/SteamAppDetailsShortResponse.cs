using System.Text.Json.Serialization;
using SteamApis.Net.Entities.Response.Market.App;

namespace SteamApis.Net.Entities.Response.Market.Apps;

public record SteamAppDetailsShortResponse
{
    [JsonPropertyName("appID")]
    public int AppId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("is_free")]
    public bool IsFree { get; init; }

    [JsonPropertyName("price_overview")]
    public PriceOverview? PriceOverview { get; init; }
}