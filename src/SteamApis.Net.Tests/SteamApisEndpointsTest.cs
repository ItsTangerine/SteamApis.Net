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
    private const int TestAppId = 252490;
    private const string TestItemName = "Black Hoodie";

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
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetUserSteamProfile_ValidSteamId_ReturnsProfile()
    {
        var result = await _client.GetUserSteamProfile(TestSteamId);
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public async Task GetUserSteamProfile_InValidSteamId_ReturnsFail()
    {
        var result = await _client.GetUserSteamProfile("123456");
        Assert.False(result.IsSuccess);
    }
    
    [Fact]
    public async Task GetUserSteamSummary_ValidSteamId_ReturnsSummary()
    {
        var result = await _client.GetUserSteamSummary(TestSteamId);
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public async Task GetUserSteamVanity_ValidVanityUrl_ReturnsSteam()
    {
        var result = await _client.GetUserSteamVanity(TestVanityUrl);
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public async Task GetUserSteamGames_ValidSteamId_ReturnsGames()
    {
        var result = await _client.GetUserSteamGames(TestSteamId);
        Assert.True(result.IsSuccess);
    }

    // Disabled since not working properly on API side.
    /*[Fact]
    public async Task GetMarketStats_ReturnsStats()
    {
        var result = await _client.GetMarketStats();
        Assert.True(result.IsSuccess);
    }*/

    [Fact]
    public async Task GetSingleApp_ValidAppId_ReturnsAppDetails()
    {
        var result = await _client.GetSingleApp(TestAppId);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetAllApps_ReturnsAppsList()
    {
        var result = await _client.GetAllApps();
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetSingleItem_InValidParameters_ReturnsItemInfo()
    {
        var result = await _client.GetSingleItem(TestAppId, TestItemName);
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public async Task GetSingleItem_ValidParameters_ReturnsItemInfo()
    {
        var result = await _client.GetSingleItem(TestAppId, TestItemName);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetAllItems_ValidAppId_ReturnsItems()
    {
        var result = await _client.GetAllItems(TestAppId);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetAllItemsCompact_ValidAppId_ReturnsCompactList()
    {
        var result = await _client.GetAllItemsCompact(TestAppId);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetAllCards_ReturnsCardsList()
    {
        var result = await _client.GetAllCards();
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public async Task GetMarketDescriptions_ValidAppId_ReturnsMarketDescriptions()
    {
        var result = await _client.GetMarketDescriptions(TestAppId);
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public async Task GetMarketHistograms_ValidAppId_ReturnsMarketHistograms()
    {
        var result = await _client.GetMarketHistograms(TestAppId);
        Assert.True(result.IsSuccess);
    }
    
    [Fact]
    public async Task GetMarketAssetInfos_ValidAppId_ReturnsMarketAssetInfos()
    {
        var result = await _client.GetMarketAssetInfos(TestAppId);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetImage_ValidParameters_ReturnsImageBytes()
    {
        var result = await _client.GetImage(TestAppId, TestItemName);
        Assert.True(result.IsSuccess);
    }

    [Fact]
    public async Task GetImages_ValidAppId_ReturnsImagesDictionary()
    {
        var result = await _client.GetImages(TestAppId);
        Assert.True(result.IsSuccess);
    }

}