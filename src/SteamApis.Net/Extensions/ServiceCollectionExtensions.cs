using System.Net;
using Microsoft.Extensions.DependencyInjection;
using SteamApis.Net.Clients;
using SteamApis.Net.Constants;
using SteamApis.Net.Services;

namespace SteamApis.Net.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="ISteamApisClient"/> as a singleton in the DI container.
    /// </summary>
    public static IServiceCollection AddSteamApis(
        this IServiceCollection services,
        string apiKey,
        Action<HttpClient>? configureClient = null)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(apiKey);
 
        services.AddHttpClient<SteamApiClient>("SteamApis.Steam", client =>
        {
            client.BaseAddress = new Uri(DefaultEndpoints.SteamBaseUrl);
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            configureClient?.Invoke(client);
        }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            AutomaticDecompression =
                DecompressionMethods.GZip |
                DecompressionMethods.Deflate |
                DecompressionMethods.Brotli
        });
 
        services.AddHttpClient<MarketPlaceApiClient>("SteamApis.Market", client =>
        {
            client.BaseAddress = new Uri(DefaultEndpoints.MarketBaseUrl);
            client.DefaultRequestHeaders.Add("x-api-key", apiKey);
            configureClient?.Invoke(client);
        }).ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler
        {
            AutomaticDecompression =
                DecompressionMethods.GZip |
                DecompressionMethods.Deflate |
                DecompressionMethods.Brotli
        });
        
        services.AddTransient<ISteamApisClient>(sp =>
            new SteamApisClient(
                sp.GetRequiredService<SteamApiClient>(),
                sp.GetRequiredService<MarketPlaceApiClient>()));
 
        return services;
    }
}