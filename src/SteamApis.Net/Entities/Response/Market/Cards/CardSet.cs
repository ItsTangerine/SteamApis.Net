using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Cards;

public record CardSet
{
    [JsonPropertyName("appid")]
    public string AppId { get; init; } = default!;

    [JsonPropertyName("game")]
    public string Game { get; init; } = default!;

    [JsonPropertyName("normal")]
    public CardRarityGroup Normal { get; init; } = default!;

    [JsonPropertyName("foil")]
    public CardRarityGroup Foil { get; init; } = default!;
}