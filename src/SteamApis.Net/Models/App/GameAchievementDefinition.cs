using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class GameAchievementDefinition
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("defaultvalue")]
    public double DefaultValue { get; init; }

    [JsonPropertyName("displayName")]
    public required string DisplayName { get; init; }

    [JsonPropertyName("hidden")]
    public int Hidden { get; init; }

    [JsonPropertyName("description")]
    public string? Description { get; init; }

    [JsonPropertyName("icon")]
    public required string Icon { get; init; }

    [JsonPropertyName("icongray")]
    public required string IconGray { get; init; }
}