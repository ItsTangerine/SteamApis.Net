using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.App;

public record Category
{
    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }
}