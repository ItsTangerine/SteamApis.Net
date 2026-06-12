using System.Text.Json.Serialization;
using SteamApis.Net.Models.App;

namespace SteamApis.Net.Models.Common;

public sealed class ChangeLogEntry
{
    [JsonPropertyName("_id")]
    public required string Id { get; init; }

    [JsonPropertyName("changes")]
    public Dictionary<string, FieldChange> Changes { get; init; } = [];

    [JsonPropertyName("createdAt")]
    public DateTimeOffset CreatedAt { get; init; }
}