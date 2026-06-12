using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class ItemColor
{
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("background")]
    public string? Background { get; init; }
}