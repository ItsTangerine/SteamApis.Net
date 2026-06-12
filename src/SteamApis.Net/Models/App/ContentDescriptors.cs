using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class ContentDescriptors
{
    [JsonPropertyName("ids")]
    public IReadOnlyList<int> Ids { get; init; } = [];

    [JsonPropertyName("notes")]
    public string? Notes { get; init; }
}