using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class GameStatDefinition
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("defaultvalue")]
    public double DefaultValue { get; init; }

    [JsonPropertyName("displayName")]
    public required string DisplayName { get; init; }
}