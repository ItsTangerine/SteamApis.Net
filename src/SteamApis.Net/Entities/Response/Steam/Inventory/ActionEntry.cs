using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Inventory;

public record ActionEntry
{
    [JsonPropertyName("link")]
    public string Link { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;
}