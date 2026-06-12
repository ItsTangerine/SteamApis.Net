using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class AppAchievementSummary
{
    [JsonPropertyName("total")]
    public int Total { get; init; }
}