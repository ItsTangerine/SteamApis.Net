using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class InventoryAsset
{
    [JsonPropertyName("appid")]
    public int AppId { get; init; }
 
    [JsonPropertyName("contextid")]
    public string? ContextId { get; init; }
 
    [JsonPropertyName("assetid")]
    public string? AssetId { get; init; }
 
    [JsonPropertyName("classid")]
    public string? ClassId { get; init; }
 
    [JsonPropertyName("instanceid")]
    public string? InstanceId { get; init; }
 
    [JsonPropertyName("amount")]
    public string? Amount { get; init; }
}