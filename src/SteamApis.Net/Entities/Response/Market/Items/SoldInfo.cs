using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Items;

public record SoldInfo
{
    [JsonPropertyName("last_24h")]
    public int Last24h { get; init; }

    [JsonPropertyName("last_7d")]
    public int Last7d { get; init; }

    [JsonPropertyName("last_30d")]
    public int Last30d { get; init; }

    [JsonPropertyName("last_90d")]
    public int Last90d { get; init; }

    [JsonPropertyName("avg_daily_volume")]
    public int AvgDailyVolume { get; init; }
}