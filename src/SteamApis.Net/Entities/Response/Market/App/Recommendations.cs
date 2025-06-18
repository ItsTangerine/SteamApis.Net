using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.App;

public record Recommendations
{
    [JsonPropertyName("total")]
    public int Total { get; init; }
}