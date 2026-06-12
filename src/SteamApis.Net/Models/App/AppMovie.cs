using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppMovie
{
    [JsonPropertyName("id")]
    public int Id { get; init; }

    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("thumbnail")]
    public required string Thumbnail { get; init; }

    [JsonPropertyName("dashAv1")]
    public string? DashAv1 { get; init; }

    [JsonPropertyName("dashH264")]
    public string? DashH264 { get; init; }

    [JsonPropertyName("hlsH264")]
    public string? HlsH264 { get; init; }

    [JsonPropertyName("highlight")]
    public bool Highlight { get; init; }
}