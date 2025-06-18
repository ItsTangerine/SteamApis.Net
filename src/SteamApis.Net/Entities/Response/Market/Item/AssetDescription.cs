using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Item;

public record AssetDescription
{
    [JsonPropertyName("type")]
    public string Type { get; init; } = default!;

    [JsonPropertyName("value")]
    public string Value { get; init; } = default!;

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("color")]
    public string? Color { get; init; }

    [JsonPropertyName("app_data")]
    public Dictionary<string, string>? AppData { get; init; }
}