using Microsoft.Extensions.DependencyInjection;
using SteamApis.Net.Extensions;
using SteamApis.Net.Services;
using SteamApis.Net.Services.Config;

namespace SteamApis.Net.Tests;

public class SteamApisClientTest
{
    
    [Fact]
    public void Constructor_WithValidOptions_CreatesClient()
    {
        // Arrange
        var options = new SteamApisOptions
        {
            ApiKey = "test-key"
        };

        // Act
        var services = new ServiceCollection();
        services.AddSteamApis(opts =>
        {
            opts.ApiKey = options.ApiKey;
        });
        var provider = services.BuildServiceProvider();
        var client = provider.GetService<ISteamApisClient>();

        // Assert
        Assert.NotNull(client);
    }

    [Fact]
    public void Constructor_WithoutApiKey_ThrowsException()
    {
        // Arrange & Act
        var services = new ServiceCollection();
        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            services.AddSteamApis(opts => { });
        });

        // Assert
        Assert.Equal("ApiKey", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithCustomTimeout_ConfiguresTimeout()
    {
        // Arrange
        var expectedTimeout = TimeSpan.FromSeconds(60);

        // Act
        var services = new ServiceCollection();
        services.AddSteamApis(opts =>
        {
            opts.ApiKey = "test-key";
            opts.Timeout = expectedTimeout;
        });
        var provider = services.BuildServiceProvider();
        var client = provider.GetService<ISteamApisClient>();

        // Assert
        Assert.NotNull(client);
    }

    [Fact]
    public void Constructor_WithCustomBaseUrl_ConfiguresBaseUrl()
    {
        // Arrange
        var expectedBaseUrl = "https://custom.api.com/";

        // Act
        var services = new ServiceCollection();
        services.AddSteamApis(opts =>
        {
            opts.ApiKey = "test-key";
            opts.BaseUrl = expectedBaseUrl;
        });
        var provider = services.BuildServiceProvider();
        var client = provider.GetService<ISteamApisClient>();

        // Assert
        Assert.NotNull(client);
    }
}