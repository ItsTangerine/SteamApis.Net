using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Cards;

public record SteamCardSetResponse
{
    [JsonPropertyName("data")]
    public SteamCardSetData Data { get; init; } = default!;
}