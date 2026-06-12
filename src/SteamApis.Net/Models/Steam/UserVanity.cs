using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class UserVanity
{
    [JsonPropertyName("steamID")]
    public string SteamId { get; init; } = string.Empty;
}