using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Inventory;

public record Asset
{
    [JsonPropertyName("appid")]
    public int AppId { get; init; }

    [JsonPropertyName("contextid")]
    public string ContextId { get; init; } = null!;

    [JsonPropertyName("assetid")]
    public string AssetId { get; init; } = null!;

    [JsonPropertyName("classid")]
    public string ClassId { get; init; } = null!;

    [JsonPropertyName("instanceid")]
    public string InstanceId { get; init; } = null!;

    [JsonPropertyName("amount")]
    public string Amount { get; init; } = null!;
}