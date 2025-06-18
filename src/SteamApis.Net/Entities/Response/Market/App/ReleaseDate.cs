using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.App;

public record ReleaseDate
{
    [JsonPropertyName("date")]
    public string? Date { get; init; }

    [JsonPropertyName("coming_soon")]
    public bool ComingSoon { get; init; }
}