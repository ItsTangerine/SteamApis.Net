using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.App;

public sealed class FieldChange
{
    [JsonPropertyName("old")]
    public object? Old { get; init; }

    [JsonPropertyName("new")]
    public object? New { get; init; }
}