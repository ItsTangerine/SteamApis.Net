using SteamApis.Net.Tests.Helpers;

namespace SteamApis.Net.Tests.Integration.Steam;

[Collection("SteamLegacy")]
public sealed class SteamLegacyIntegrationTests(IntegrationFixture fx) : IClassFixture<IntegrationFixture>
{
    [Fact]
    public async Task GetUserSteamInventory_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetUserSteamInventory(fx.SteamId, fx.AppId, 2);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value.Assets);
    }
    
    [Fact]
    public async Task GetUserSteamProfile_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetUserSteamProfile(fx.SteamId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value.Name);
    }
    
    [Fact]
    public async Task GetUserSteamVanity_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetUserSteamVanity(fx.VanityUrl);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value.SteamId);
    }
    
    [Fact]
    public async Task GetUserSteamSummary_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetUserSteamSummary(fx.SteamId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value.SteamId);
    }
    
    [Fact]
    public async Task GetUserSteamGames_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetUserSteamGames(fx.SteamId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value.Games);
    }
    
    [Fact]
    public async Task GetMarketStats_Succeeds()
    {
        try
        {
            var result = await fx.Steam.Legacy.GetMarketStats().WaitAsync(TimeSpan.FromSeconds(10));
            AssertHelpers.AssertSuccess(result);
        }
        catch (TimeoutException)
        {
            // since endpoint mostly doesn't respond we can ignore it
        }
    }
    
    [Fact]
    public async Task GetSingleApp_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetSingleApp(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        Assert.Equal(result.Value.AppId, fx.AppId);
    }
    
    [Fact]
    public async Task GetAllApps_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetAllApps();

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value);
    }
    
    [Fact]
    public async Task GetSingleItem_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetSingleItem(fx.AppId, fx.MarketHashName);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value.MedianAvgPrices15Days);
    }
    
    [Fact]
    public async Task GetAllItems_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetAllItems(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value.Data);
    }
    
    [Fact]
    public async Task GetAllItemsCompact_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetAllItemsCompact(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value);
    }
    
    [Fact]
    public async Task GetAllCards_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetAllCards();

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value.Data.Sets);
    }
    
    [Fact]
    public async Task GetMarketDescriptions_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetMarketDescriptions(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value.Data);
    }
    
    [Fact]
    public async Task GetMarketHistograms_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetMarketHistograms(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value);
    }
    
    [Fact]
    public async Task GetMarketAssetInfos_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetMarketAssetInfos(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value.Results);
    }
    
    [Fact]
    public async Task GetImage_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetImage(fx.AppId, fx.MarketHashName);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value);
    }
    
    [Fact]
    public async Task GetImages_Succeeds()
    {
        var result = await fx.Steam.Legacy.GetImages(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value);
    }
}