using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Games;

public record SteamOwnedGame
{
    [JsonPropertyName("appid")]
    public int AppId { get; init; }

    [JsonPropertyName("playtime_forever")]
    public int PlaytimeForever { get; init; }

    [JsonPropertyName("playtime_2weeks")]
    public int? Playtime2Weeks { get; init; }
}