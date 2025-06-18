using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.App;

public record Platforms
{
    [JsonPropertyName("linux")]
    public bool Linux { get; init; }

    [JsonPropertyName("mac")]
    public bool Mac { get; init; }

    [JsonPropertyName("windows")]
    public bool Windows { get; init; }
}
