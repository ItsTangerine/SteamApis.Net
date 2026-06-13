using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.App;

public record Requirements
{
    [JsonPropertyName("minimum")]
    public string? Minimum { get; init; }
    
    [JsonPropertyName("recommended")]
    public string? Recommended { get; init; }
}