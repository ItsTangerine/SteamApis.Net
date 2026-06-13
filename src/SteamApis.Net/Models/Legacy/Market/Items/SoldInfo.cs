using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Items;

public record SoldInfo
{
    [JsonPropertyName("last_24h")]
    public int Last24Hours { get; init; }

    [JsonPropertyName("last_7d")]
    public int Last7Days { get; init; }

    [JsonPropertyName("last_30d")]
    public int Last30Days { get; init; }

    [JsonPropertyName("last_90d")]
    public int Last90Days { get; init; }

    [JsonPropertyName("avg_daily_volume")]
    public int? AvgDailyVolume { get; init; }
}