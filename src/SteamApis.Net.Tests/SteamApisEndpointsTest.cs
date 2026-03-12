using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SteamApis.Net.Extensions;
using SteamApis.Net.Services;

namespace SteamApis.Net.Tests;

public class SteamApisEndpointsTest
{
    private readonly ISteamApisClient _client;
    private const string TestSteamId = "76561198869937617";
    private const string TestVanityUrl = "itstangerine";
    private const int TestAppId = 730;
    private const string TestItemName = "AK-47 | Asiimov (Field-Tested)";

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
        var result = await _client.GetUserSteamInventory(TestSteamId, TestAppId, 2);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetUserSteamProfile_ValidSteamId_ReturnsProfile()
    {
        var result = await _client.GetUserSteamProfile(TestSteamId);
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetUserSteamSummary_ValidSteamId_ReturnsSummary()
    {
        var result = await _client.GetUserSteamSummary(TestSteamId);
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetUserSteamVanity_ValidVanityUrl_ReturnsSteam()
    {
        var result = await _client.GetUserSteamVanity(TestVanityUrl);
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetUserSteamGames_ValidSteamId_ReturnsGames()
    {
        var result = await _client.GetUserSteamGames(TestSteamId);
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
        var result = await _client.GetSingleApp(TestAppId);
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
        var result = await _client.GetSingleItem(TestAppId, TestItemName);
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetSingleItem_ValidParameters_ReturnsItemInfo()
    {
        var result = await _client.GetSingleItem(TestAppId, TestItemName);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetAllItems_ValidAppId_ReturnsItems()
    {
        var result = await _client.GetAllItems(TestAppId);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetAllItemsCompact_ValidAppId_ReturnsCompactList()
    {
        var result = await _client.GetAllItemsCompact(TestAppId);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetAllCards_ReturnsCardsList()
    {
        var result = await _client.GetAllCards();
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetMarketDescriptions_ValidAppId_ReturnsMarketDescriptions()
    {
        var result = await _client.GetMarketDescriptions(TestAppId);
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetMarketHistograms_ValidAppId_ReturnsMarketHistograms()
    {
        var result = await _client.GetMarketHistograms(TestAppId);
        Assert.NotNull(result);
    }
    
    [Fact]
    public async Task GetMarketAssetInfos_ValidAppId_ReturnsMarketAssetInfos()
    {
        var result = await _client.GetMarketAssetInfos(TestAppId);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetImage_ValidParameters_ReturnsImageBytes()
    {
        var result = await _client.GetImage(TestAppId, TestItemName);
        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetImages_ValidAppId_ReturnsImagesDictionary()
    {
        var result = await _client.GetImages(TestAppId);
        Assert.NotNull(result);
    }

}