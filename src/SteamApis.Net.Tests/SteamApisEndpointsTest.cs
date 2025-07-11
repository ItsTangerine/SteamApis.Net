using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SteamApis.Net.Extensions;
using SteamApis.Net.Services;

namespace SteamApis.Net.Tests;

public class SteamApisEndpointsTest
{
    private readonly ISteamApisClient _client;

    public SteamApisEndpointsTest()
    {
        var config = new ConfigurationBuilder()
            .AddEnvironmentVariables()
            .AddUserSecrets(typeof(SteamApisEndpointsTest).Assembly)
            .Build();

        var apiKey = config["SteamApis:Key"];
        ArgumentNullException.ThrowIfNull(apiKey, nameof(apiKey));
        
        var services = new ServiceCollection();
        services.AddSteamApis(options =>
        {
            options.ApiKey = apiKey;
            options.Timeout = TimeSpan.FromMinutes(2);
        });
        var provider = services.BuildServiceProvider();
        _client = provider.GetRequiredService<ISteamApisClient>();
    }
    
    [Fact]
    public async Task GetUserSteamInventory_ValidArgs_ReturnsInventory()
    {
        var result = await _client.GetUserSteamInventory("76561198869937617", 730, 2);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetUserSteamProfile_ValidSteamId_ReturnsProfile()
    {
        var result = await _client.GetUserSteamProfile("76561198869937617");
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetMarketStats_ReturnsStats()
    {
        var result = await _client.GetMarketStats();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetSingleApp_ValidAppId_ReturnsAppDetails()
    {
        var result = await _client.GetSingleApp(730);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetAllApps_ReturnsAppsList()
    {
        var result = await _client.GetAllApps();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetSingleItem_InValidParameters_ReturnsItemInfo()
    {
        var result = await _client.GetSingleItem(730, "AK-47 | Asiimov (Field-Tested)");
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetSingleItem_ValidParameters_ReturnsItemInfo()
    {
        var result = await _client.GetSingleItem(730, "AK-47 | Asiimov (Field-Tested)");
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetAllItems_ValidAppId_ReturnsItems()
    {
        var result = await _client.GetAllItems(730);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetAllItemsCompact_ValidAppId_ReturnsCompactList()
    {
        var result = await _client.GetAllItemsCompact(730);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetAllCards_ReturnsCardsList()
    {
        var result = await _client.GetAllCards();
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetImage_ValidParameters_ReturnsImageBytes()
    {
        var result = await _client.GetImage(730, "AK-47 | Asiimov (Field-Tested)");
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetImages_ValidAppId_ReturnsImagesDictionary()
    {
        var result = await _client.GetImages(730);
        Assert.NotNull(result);
    }

}