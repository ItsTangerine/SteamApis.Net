using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.App;

public record SteamAppDetailsResponse
{
    [JsonPropertyName("appID")]
    public int AppId { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("is_free")]
    public bool IsFree { get; init; }

    [JsonPropertyName("header_image")]
    public string? HeaderImage { get; init; }

    [JsonPropertyName("background")]
    public string? Background { get; init; }

    [JsonPropertyName("requirements")]
    public Requirements? Requirements { get; init; }

    [JsonPropertyName("developers")]
    public string[]? Developers { get; init; }

    [JsonPropertyName("publishers")]
    public string[]? Publishers { get; init; }

    [JsonPropertyName("detailed_description")]
    public string? DetailedDescription { get; init; }

    [JsonPropertyName("short_description")]
    public string? ShortDescription { get; init; }

    [JsonPropertyName("about_the_game")]
    public string? AboutTheGame { get; init; }

    [JsonPropertyName("website")]
    public string? Website { get; init; }

    [JsonPropertyName("price_overview")]
    public PriceOverview? PriceOverview { get; init; }

    [JsonPropertyName("platforms")]
    public Platforms? Platforms { get; init; }

    [JsonPropertyName("categories")]
    public Category[]? Categories { get; init; }

    [JsonPropertyName("genres")]
    public Genre[]? Genres { get; init; }

    [JsonPropertyName("recommendations")]
    public Recommendations? Recommendations { get; init; }

    [JsonPropertyName("screenshots")]
    public Screenshot[]? Screenshots { get; init; }

    [JsonPropertyName("release_date")]
    public ReleaseDate? ReleaseDate { get; init; }

    [JsonPropertyName("updated_at")]
    public long UpdatedAt { get; init; }
}