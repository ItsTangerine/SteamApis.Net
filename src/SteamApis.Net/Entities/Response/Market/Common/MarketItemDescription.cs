using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Common;

public record MarketItemDescription
{
    [JsonPropertyName("value")]
    public string Value { get; init; } = null!;

    [JsonPropertyName("type")]
    public string Type { get; init; } = null!;
}