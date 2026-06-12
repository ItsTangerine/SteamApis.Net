using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class RankedApp
{
    [JsonPropertyName("appId")]
    public int AppId { get; init; }

    [JsonPropertyName("rank")]
    public int Rank { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }
}