using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppPackageGroup
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("title")]
    public required string Title { get; init; }

    [JsonPropertyName("description")]
    public required string Description { get; init; }
}