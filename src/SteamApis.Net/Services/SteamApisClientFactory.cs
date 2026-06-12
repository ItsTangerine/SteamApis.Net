using System.Net;
using SteamApis.Net.Clients;
using SteamApis.Net.Constants;

namespace SteamApis.Net.Services;

public static class SteamApisClientFactory
{
    /// <summary>Creates an <see cref="ISteamApisClient"/> without a DI container.</summary>
    public static ISteamApisClient Create(string apiKey)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(apiKey);
 
        var steamHttp = CreateHttpClient(DefaultEndpoints.SteamBaseUrl, apiKey);
        var marketHttp = CreateHttpClient(DefaultEndpoints.MarketBaseUrl, apiKey);
 
        return new SteamApisClient(
            new SteamApiClient(steamHttp),
            new MarketPlaceApiClient(marketHttp));
    }
 
    private static HttpClient CreateHttpClient(string baseUrl, string apiKey)
    {
        var handler = new HttpClientHandler
        {
            AutomaticDecompression =
                DecompressionMethods.GZip |
                DecompressionMethods.Deflate |
                DecompressionMethods.Brotli
        };
        
        var client = new HttpClient(handler) { BaseAddress = new Uri(baseUrl) };
        client.DefaultRequestHeaders.Add("x-api-key", apiKey);
        return client;
    }
}