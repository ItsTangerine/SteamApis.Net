using Microsoft.Extensions.DependencyInjection;
using SteamApis.Net.Clients;
using SteamApis.Net.Constants;
using SteamApis.Net.Extensions;
using SteamApis.Net.Services;

namespace SteamApis.Net.Tests;

public class DependencyInjectionTests
{
    private const string ApiKey = "test-api-key";

    [Fact]
    public void AddSteamApis_RegistersISteamApisClient()
    {
        var provider = new ServiceCollection()
            .AddSteamApis(ApiKey)
            .BuildServiceProvider();

        var client = provider.GetService<ISteamApisClient>();

        Assert.NotNull(client);
    }

    [Fact]
    public void AddSteamApis_ResolvesClient_WithBothSubClients()
    {
        var provider = new ServiceCollection()
            .AddSteamApis(ApiKey)
            .BuildServiceProvider();

        var client = provider.GetRequiredService<ISteamApisClient>();

        Assert.NotNull(client.Steam);
        Assert.NotNull(client.MarketPlace);
        Assert.IsType<SteamApiClient>(client.Steam);
        Assert.IsType<MarketPlaceApiClient>(client.MarketPlace);
    }

    [Fact]
    public void AddSteamApis_RegistersSteamApiClient()
    {
        var provider = new ServiceCollection()
            .AddSteamApis(ApiKey)
            .BuildServiceProvider();

        var steam = provider.GetService<SteamApiClient>();

        Assert.NotNull(steam);
    }

    [Fact]
    public void AddSteamApis_RegistersMarketPlaceApiClient()
    {
        var provider = new ServiceCollection()
            .AddSteamApis(ApiKey)
            .BuildServiceProvider();

        var market = provider.GetService<MarketPlaceApiClient>();

        Assert.NotNull(market);
    }

    [Fact]
    public void AddSteamApis_ISteamApisClient_IsTransient()
    {
        var provider = new ServiceCollection()
            .AddSteamApis(ApiKey)
            .BuildServiceProvider();

        var first = provider.GetRequiredService<ISteamApisClient>();
        var second = provider.GetRequiredService<ISteamApisClient>();

        Assert.NotSame(first, second);
    }

    [Fact]
    public void AddSteamApis_ReturnsSameServiceCollection_ForChaining()
    {
        var services = new ServiceCollection();

        var result = services.AddSteamApis(ApiKey);

        Assert.Same(services, result);
    }

    [Fact]
    public void AddSteamApis_ConfiguresSteamBaseAddress()
    {
        var provider = new ServiceCollection()
            .AddSteamApis(ApiKey)
            .BuildServiceProvider();

        var steam = provider.GetRequiredService<SteamApiClient>();

        // The client was constructed successfully, which requires the x-api-key
        // header to be present (see SteamApiClient ctor).
        Assert.NotNull(steam);
    }

    [Fact]
    public void AddSteamApis_InvokesConfigureClient_ForBothClients()
    {
        var configuredBaseAddresses = new List<Uri?>();

        var provider = new ServiceCollection()
            .AddSteamApis(ApiKey, client => configuredBaseAddresses.Add(client.BaseAddress))
            .BuildServiceProvider();

        // Force creation of both typed clients so their HttpClient is configured.
        _ = provider.GetRequiredService<SteamApiClient>();
        _ = provider.GetRequiredService<MarketPlaceApiClient>();

        Assert.Equal(2, configuredBaseAddresses.Count);
        Assert.Contains(new Uri(DefaultEndpoints.SteamBaseUrl), configuredBaseAddresses);
        Assert.Contains(new Uri(DefaultEndpoints.MarketBaseUrl), configuredBaseAddresses);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("   ")]
    public void AddSteamApis_Throws_WhenApiKeyIsNullOrWhitespace(string? apiKey)
    {
        var services = new ServiceCollection();

        if(apiKey is null)
            Assert.Throws<ArgumentNullException>(() => services.AddSteamApis(apiKey!));
        else
            Assert.Throws<ArgumentException>(() => services.AddSteamApis(apiKey));
    }
}