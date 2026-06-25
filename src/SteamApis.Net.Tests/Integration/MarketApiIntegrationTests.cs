using SteamApis.Net.Tests.Helpers;

namespace SteamApis.Net.Tests.Integration;

[Collection("MarketplaceIntegration")]
public sealed class MarketApiIntegrationTests(IntegrationFixture fx) : IClassFixture<IntegrationFixture>
{
    [Fact]
    public async Task ListMarketplacesAsync_ReturnsNonEmptyList()
    {
        var result = await fx.MarketPlace.ListAsync();

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value);
        Assert.All(result.Value, m =>
            Assert.False(string.IsNullOrWhiteSpace(m.Marketplace)));
    }

    [Fact]
    public async Task GetItemAsync_ReturnsMatchingMarketHashName()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.MarketPlace.GetItemAsync(fx.Marketplace, appTestData.GameCode, appTestData.MarketHashName);

            AssertHelpers.AssertSuccess(result);
            Assert.Equal(appTestData.GameCode, result.Value.Game);
        }
    }

    [Fact]
    public async Task GetItemAsync_WithMarketplace_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.MarketPlace.GetItemAsync(fx.Marketplace, appTestData.GameCode, appTestData.MarketHashName);

            AssertHelpers.AssertSuccess(result);
        }
    }

    [Fact]
    public async Task SearchItemsAsync_ReturnsResults()
    {
        foreach (var appTestData in fx.AppData)
        {
            // Use first word of market hash name as a generic search term
            var query = appTestData.MarketHashName.Split(' ')[0];
            
            var result = await fx.MarketPlace.SearchItemsAsync(appTestData.GameCode, query);

            AssertHelpers.AssertSuccess(result);
            Assert.NotEmpty(result.Value);
        }
    }

    [Fact]
    public async Task CompareItemAsync_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.MarketPlace.CompareItemAsync(appTestData.GameCode, appTestData.MarketHashName, [fx.Marketplace]);

            AssertHelpers.AssertSuccess(result);
            Assert.NotEmpty(result.Value.Marketplaces);
        }
    }

    [Fact]
    public async Task GetPriceHistoryAsync_ReturnsNonEmptyList()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.MarketPlace.GetPriceHistoryAsync(fx.Marketplace, appTestData.GameCode, appTestData.MarketHashName);

            AssertHelpers.AssertSuccess(result);
            Assert.NotEmpty(result.Value.History);
        }
    }

    [Fact]
    public async Task GetSalesHistoryAsync_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.MarketPlace.GetSalesHistoryAsync(fx.Marketplace, appTestData.GameCode, appTestData.MarketHashName);

            AssertHelpers.AssertSuccess(result);
            Assert.NotEmpty(result.Value.Sales);
        }
    }

    [Fact]
    public async Task GetBuyOrdersAsync_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.MarketPlace.GetBuyOrdersAsync(fx.Marketplace, appTestData.GameCode, appTestData.MarketHashName);

            AssertHelpers.AssertSuccess(result);
            Assert.NotEmpty(result.Value);
        }
    }
}