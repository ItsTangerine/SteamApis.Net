using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppRecommendationSummary
{
    [JsonPropertyName("total")]
    public int Total { get; init; }
}