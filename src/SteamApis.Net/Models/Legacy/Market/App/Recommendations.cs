using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.App;

public record Recommendations
{
    [JsonPropertyName("total")]
    public int Total { get; init; }
}