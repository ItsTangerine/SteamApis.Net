using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class GameMeta : GameMetaBase
{
    [JsonPropertyName("hasCommunityVisibleStats")]
    public bool HasCommunityVisibleStats { get; init; }

    [JsonPropertyName("hasLeaderboards")]
    public bool HasLeaderboards { get; init; }

    [JsonPropertyName("descriptorIDs")]
    public IReadOnlyList<int>? DescriptorIds { get; init; }

    [JsonPropertyName("hasWorkshop")]
    public bool HasWorkshop { get; init; }

    [JsonPropertyName("hasMarket")]
    public bool HasMarket { get; init; }

    [JsonPropertyName("hasDLC")]
    public bool HasDlc { get; init; }

    [JsonPropertyName("capsuleFilename")]
    public required string CapsuleFilename { get; init; }
    
    public string GetIconUrl(int appId) => $"https://media.steampowered.com/steamcommunity/public/images/apps/{appId}/{Icon}.jpg";
}