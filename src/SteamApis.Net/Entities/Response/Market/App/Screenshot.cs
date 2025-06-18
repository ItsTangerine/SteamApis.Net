using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.App;

public record Screenshot
{
    [JsonPropertyName("path_full")]
    public string? PathFull { get; init; }

    [JsonPropertyName("path_thumbnail")]
    public string? PathThumbnail { get; init; }

    [JsonPropertyName("id")]
    public int Id { get; init; }
}