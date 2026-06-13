using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class UserVanity
{
    [JsonPropertyName("steamID")]
    public required string SteamId { get; init; }
}