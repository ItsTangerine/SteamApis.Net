namespace SteamApis.Net.Services.Config;

public class SteamApisOptions
{
    public string? ApiKey { get; set; }
    public string BaseUrl { get; set; } = "https://api.steamapis.com/";
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
}