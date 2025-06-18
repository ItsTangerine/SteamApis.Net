using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.App;

public record PriceOverview
{
    [JsonPropertyName("final_formatted")]
    public string? FinalFormatted { get; init; }

    [JsonPropertyName("initial_formatted")]
    public string? InitialFormatted { get; init; }

    [JsonPropertyName("discount_percent")]
    public int DiscountPercent { get; init; }

    [JsonPropertyName("final")]
    public int Final { get; init; }

    [JsonPropertyName("initial")]
    public int Initial { get; init; }

    [JsonPropertyName("currency")]
    public string? Currency { get; init; }
}