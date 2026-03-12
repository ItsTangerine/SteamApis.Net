using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Games;

public record SteamGamesResponse
{
    [JsonPropertyName("game_count")]
    public int GameCount { get; init; }

    [JsonPropertyName("games")]
    public List<SteamOwnedGame> Games { get; init; } = [];
}