using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response;

public class ErrorResponse
{
    [JsonPropertyName("error")]
    public string Error { get; set; } = null!;
}