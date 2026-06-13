using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.App;

public record Category
{
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }
}