using System.Net;
using Microsoft.Extensions.Configuration;
using SteamApis.Net.Clients;
using SteamApis.Net.Constants;
using SteamApis.Net.Tests.Models;

namespace SteamApis.Net.Tests.Integration;

/// <summary>
/// xUnit class fixture that builds real HTTP clients from user-secrets.
/// Shared across all integration test classes that accept it.
/// </summary>
public sealed class IntegrationFixture : IDisposable
{
    public SteamApiClient Steam { get; }
    public MarketPlaceApiClient MarketPlace { get; }

    // Fixture values loaded from secrets / env
    public string ApiKey { get; }
    public string SteamId { get; }
    public string VanityUrl { get; }
    public AppTestData[] AppData { get; }
    public string Marketplace { get; }

    private readonly HttpClient _steamHttp;
    private readonly HttpClient _marketHttp;

    public IntegrationFixture()
    {
        var config = new ConfigurationBuilder()
            .AddUserSecrets<IntegrationFixture>()
            .AddEnvironmentVariables()
            .Build();

        ApiKey         = Required(config, "ApiKey");
        SteamId        = Required(config, "SteamId");
        VanityUrl      = Required(config, "VanityUrl");
        AppData        = Required<AppTestData[]>(config, "AppData");
        Marketplace    = Required(config, "Marketplace");

        _steamHttp = BuildHttp(DefaultEndpoints.SteamBaseUrl,  ApiKey);
        _marketHttp = BuildHttp(DefaultEndpoints.MarketBaseUrl, ApiKey);

        Steam  = new SteamApiClient(_steamHttp);
        MarketPlace = new MarketPlaceApiClient(_marketHttp);
    }

    private static HttpClient BuildHttp(string baseUrl, string apiKey)
    {
        var handler    = new HttpClientHandler()
        {
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate | DecompressionMethods.Brotli
        };
        var httpClient = new HttpClient(handler) { BaseAddress = new Uri(baseUrl) };
        httpClient.DefaultRequestHeaders.Add("x-api-key", apiKey);
        return httpClient;
    }
    
    private static T Required<T>(IConfiguration config, string key)
    {
        var obj = config.GetSection(key).Get<T>();

        if (obj is null)
            throw new InvalidOperationException(
                $"Integration test secret '{key}' is missing or empty. ");

        return obj;
    }
    
    private static string Required(IConfiguration cfg, string key) =>
        cfg[key] ?? throw new InvalidOperationException(
            $"Integration test secret '{key}' is missing. ");

    public void Dispose()
    {
        _steamHttp.Dispose();
        _marketHttp.Dispose();
    }
}