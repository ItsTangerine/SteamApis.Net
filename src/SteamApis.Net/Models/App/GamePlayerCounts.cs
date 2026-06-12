using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class GamePlayerCounts
{
    [JsonPropertyName("_id")]
    public required string Id { get; init; }
    
    [JsonPropertyName("appId")]
    public int AppId { get; init; }
    
    [JsonPropertyName("name")]
    public required string Name { get; init; }
    
    [JsonPropertyName("playerCountUpdatedAt")]
    public DateTime PlayerCountUpdatedAt { get; init; }
    
    [JsonPropertyName("meta")]
    public PlayerCounts? Meta { get; init; }
}