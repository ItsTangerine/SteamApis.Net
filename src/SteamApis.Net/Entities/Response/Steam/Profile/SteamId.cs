using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Profile;

public record SteamId
{
    [JsonPropertyName("universe")]
    public int Universe { get; init; }

    [JsonPropertyName("type")]
    public int Type { get; init; }

    [JsonPropertyName("instance")]
    public int Instance { get; init; }

    [JsonPropertyName("accountid")]
    public int AccountId { get; init; }
}