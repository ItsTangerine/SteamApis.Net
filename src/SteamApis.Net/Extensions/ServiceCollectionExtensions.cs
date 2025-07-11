using Microsoft.Extensions.DependencyInjection;
using SteamApis.Net.Services;
using SteamApis.Net.Services.Config;

namespace SteamApis.Net.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSteamApis(this IServiceCollection services, Action<SteamApisOptions> configureOptions)
    {
        var options = new SteamApisOptions();
        configureOptions(options);
        ArgumentNullException.ThrowIfNull(options.ApiKey, nameof(options.ApiKey));
        
        services.AddSingleton(options);
        
        services.AddHttpClient<ISteamApisClient, SteamApisClient>((provider, client) =>
        {
            var opts = provider.GetRequiredService<SteamApisOptions>();

            client.BaseAddress = new Uri(opts.BaseUrl);
            client.Timeout = opts.Timeout;
        });
        
        return services;
    }
}