using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Cards;

public record SteamCardSetData
{
    [JsonPropertyName("games")]
    public int Games { get; init; }

    [JsonPropertyName("cards")]
    public int Cards { get; init; }

    [JsonPropertyName("foils")]
    public int Foils { get; init; }

    [JsonPropertyName("sets")]
    public List<CardSet> Sets { get; init; } = [];
}