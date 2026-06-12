using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppRatings
{
    [JsonPropertyName("esrb")]
    public RatingEntry? Esrb { get; init; }

    [JsonPropertyName("pegi")]
    public RatingEntry? Pegi { get; init; }

    [JsonPropertyName("usk")]
    public RatingEntry? Usk { get; init; }

    [JsonPropertyName("cero")]
    public RatingEntry? Cero { get; init; }
}