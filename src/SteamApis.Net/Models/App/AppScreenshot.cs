using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppScreenshot
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("pathThumbnail")]
    public string PathThumbnail { get; init; } = default!;

    [JsonPropertyName("pathFull")]
    public string PathFull { get; init; } = default!;
}