using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.App;

public record Genre
{
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("id")]
    public string? Id { get; init; }
}