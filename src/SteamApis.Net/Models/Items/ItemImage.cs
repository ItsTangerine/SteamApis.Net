using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class ItemImage
{
    [JsonPropertyName("iconUrl")]
    public string? IconUrl { get; init; }

    [JsonPropertyName("iconUrlLarge")]
    public string? IconUrlLarge { get; init; }

    [JsonPropertyName("iconDragUrl")]
    public string? IconDragUrl { get; init; }
}