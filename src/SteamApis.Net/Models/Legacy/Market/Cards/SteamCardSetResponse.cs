using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Cards;

public record SteamCardSetResponse
{
    [JsonPropertyName("data")]
    public SteamCardSetData Data { get; init; } = default!;
}