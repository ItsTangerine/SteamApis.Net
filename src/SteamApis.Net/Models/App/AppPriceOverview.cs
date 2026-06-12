using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppPriceOverview
{
    [JsonPropertyName("currency")]
    public string? Currency { get; init; }

    [JsonPropertyName("initial")]
    public int? Initial { get; init; }

    [JsonPropertyName("final")]
    public int? Final { get; init; }

    [JsonPropertyName("discountPercent")]
    public int DiscountPercent { get; init; }

    [JsonPropertyName("initialFormatted")]
    public string? InitialFormatted { get; init; }

    [JsonPropertyName("finalFormatted")]
    public string? FinalFormatted { get; init; }
}