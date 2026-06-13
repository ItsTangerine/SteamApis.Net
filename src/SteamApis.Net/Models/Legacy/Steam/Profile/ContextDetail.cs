using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Steam.Profile;

public record ContextDetail
{
    [JsonPropertyName("asset_count")]
    public int AssetCount { get; init; }

    [JsonPropertyName("id")]
    public string Id { get; init; } = null!;

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("owner_only")]
    public bool OwnerOnly { get; init; }

    [JsonPropertyName("hide_context")]
    public bool HideContext { get; init; }
}