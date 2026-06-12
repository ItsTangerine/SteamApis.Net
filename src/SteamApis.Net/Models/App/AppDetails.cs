using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppDetails
{
    [JsonPropertyName("_id")]
    public required string Id { get; init; }

    [JsonPropertyName("appId")]
    public int AppId { get; init; }

    [JsonPropertyName("steamAppId")]
    public string? SteamAppId { get; init; }

    [JsonPropertyName("name")]
    public string? Name { get; init; }

    [JsonPropertyName("type")]
    public string? Type { get; init; }

    [JsonPropertyName("requiredAge")]
    public int RequiredAge { get; init; }

    [JsonPropertyName("isFree")]
    public bool IsFree { get; init; }

    [JsonPropertyName("shortDescription")]
    public string? ShortDescription { get; init; }

    [JsonPropertyName("detailedDescription")]
    public string? DetailedDescription { get; init; }

    [JsonPropertyName("aboutTheGame")]
    public string? AboutTheGame { get; init; }

    [JsonPropertyName("developers")]
    public IReadOnlyList<string>? Developers { get; init; }

    [JsonPropertyName("publishers")]
    public IReadOnlyList<string>? Publishers { get; init; }

    [JsonPropertyName("headerImage")]
    public string? HeaderImage { get; init; }

    [JsonPropertyName("capsuleImage")]
    public string? CapsuleImage { get; init; }

    [JsonPropertyName("capsuleImageV5")]
    public string? CapsuleImageV5 { get; init; }

    [JsonPropertyName("background")]
    public string? Background { get; init; }

    [JsonPropertyName("backgroundRaw")]
    public string? BackgroundRaw { get; init; }

    [JsonPropertyName("screenshots")]
    public IReadOnlyList<AppScreenshot> Screenshots { get; init; } = [];

    [JsonPropertyName("movies")]
    public IReadOnlyList<AppMovie> Movies { get; init; } = [];

    [JsonPropertyName("categories")]
    public IReadOnlyList<AppCategory> Categories { get; init; } = [];

    [JsonPropertyName("genres")]
    public IReadOnlyList<AppGenre> Genres { get; init; } = [];

    [JsonPropertyName("platforms")]
    public SupportedPlatforms Platforms { get; init; } = new();

    [JsonPropertyName("metacritic")]
    public Metacritic? Metacritic { get; init; }

    [JsonPropertyName("recommendations")]
    public AppRecommendationSummary? Recommendations { get; init; }

    [JsonPropertyName("achievements")]
    public AppAchievementSummary? Achievements { get; init; }

    [JsonPropertyName("releaseDate")]
    public AppReleaseDate? ReleaseDate { get; init; }

    [JsonPropertyName("supportInfo")]
    public AppSupportInfo? SupportInfo { get; init; }

    [JsonPropertyName("website")]
    public string? Website { get; init; }

    [JsonPropertyName("legalNotice")]
    public string? LegalNotice { get; init; }

    [JsonPropertyName("reviews")]
    public string? Reviews { get; init; }

    [JsonPropertyName("pcRequirements")]
    public SystemRequirements? PcRequirements { get; init; }

    [JsonPropertyName("macRequirements")]
    public SystemRequirements? MacRequirements { get; init; }

    [JsonPropertyName("linuxRequirements")]
    public SystemRequirements? LinuxRequirements { get; init; }

    [JsonPropertyName("priceOverview")]
    public AppPriceOverview? PriceOverview { get; init; }

    [JsonPropertyName("packages")]
    public IReadOnlyList<int> Packages { get; init; } = [];

    [JsonPropertyName("packageGroups")]
    public IReadOnlyList<AppPackageGroup> PackageGroups { get; init; } = [];

    [JsonPropertyName("dlc")]
    public IReadOnlyList<int> Dlc { get; init; } = [];

    [JsonPropertyName("contentDescriptors")]
    public ContentDescriptors? ContentDescriptors { get; init; }

    [JsonPropertyName("controllerSupport")]
    public string? ControllerSupport { get; init; }

    [JsonPropertyName("supportedLanguages")]
    public string? SupportedLanguages { get; init; }

    [JsonPropertyName("ratings")]
    public AppRatings? Ratings { get; init; }
}