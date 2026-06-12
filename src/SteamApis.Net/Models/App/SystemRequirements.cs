using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class SystemRequirements
{
    [JsonPropertyName("minimum")]
    public string? Minimum { get; init; }

    [JsonPropertyName("recommended")]
    public string? Recommended { get; init; }
}