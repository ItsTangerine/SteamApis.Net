using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Item;

public record AppContextData
{
    [JsonPropertyName("appid")]
    public int AppId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = default!;

    [JsonPropertyName("icon")]
    public string Icon { get; init; } = default!;

    [JsonPropertyName("link")]
    public string Link { get; init; } = default!;
}