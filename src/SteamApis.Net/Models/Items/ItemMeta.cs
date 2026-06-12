using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class ItemMeta
{
    [JsonPropertyName("appId")]
    public int AppId { get; init; }

    [JsonPropertyName("contextId")]
    public long ContextId { get; init; }

    [JsonPropertyName("classId")]
    public long ClassId { get; init; }

    [JsonPropertyName("instanceId")]
    public long InstanceId { get; init; }

    [JsonPropertyName("image")]
    public required ItemImage Image { get; init; }

    [JsonPropertyName("color")]
    public required ItemColor Color { get; init; }

    [JsonPropertyName("flags")]
    public required ItemFlags Flags { get; init; }

    [JsonPropertyName("descriptions")]
    public required IReadOnlyList<ItemDescription> Descriptions { get; init; }

    [JsonPropertyName("tags")]
    public required IReadOnlyList<ItemTag> Tags { get; init; }
}