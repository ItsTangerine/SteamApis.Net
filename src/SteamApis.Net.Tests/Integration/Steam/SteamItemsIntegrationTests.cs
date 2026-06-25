using SteamApis.Net.Tests.Helpers;

namespace SteamApis.Net.Tests.Integration.Steam;

[Collection("SteamItems")]
public sealed class SteamItemsIntegrationTests(IntegrationFixture fx) : IClassFixture<IntegrationFixture>
{
    [Fact]
    public async Task ListAsync_ReturnsPage()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Items.ListAsync(appId: appTestData.AppId);

            AssertHelpers.AssertSuccess(result);
            AssertHelpers.AssertPagedHasResults(result.Value);
        }
    }

    [Fact]
    public async Task GetDetailsAsync_ReturnsNameAndAppId()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Items.GetDetailsAsync(appTestData.AppId, appTestData.MarketHashName);

            AssertHelpers.AssertSuccess(result);
            Assert.False(string.IsNullOrWhiteSpace(result.Value.Item.Id),
                "ItemDetails.Id should be populated");
            Assert.True(result.Value.PriceHistory?.Data.Count > 0,
                "ItemDetails.PriceHistory should contain at least one price");
        }
    }

    [Fact]
    public async Task GetMetaAsync_ReturnsName()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Items.GetMetaAsync(appTestData.ItemId);

            AssertHelpers.AssertSuccess(result);
            Assert.True(result.Value.AppId != 0,
                "ItemMeta.Name should be populated");
        }
    }

    [Fact]
    public async Task GetHistogramsAsync_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Items.GetHistogramsAsync(appTestData.ItemId);

            AssertHelpers.AssertSuccess(result);
            AssertHelpers.AssertPagedHasResults(result.Value);
        }
    }

    [Fact]
    public async Task GetPricesAsync_ReturnsNonEmptyList()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Items.GetPricesAsync(appTestData.ItemId);

            AssertHelpers.AssertSuccess(result);
            Assert.NotEmpty(result.Value);
            Assert.All(result.Value, p =>
                Assert.True(p.Price >= 0, "Price should be non-negative"));
        }
    }
    
    [Fact]
    public async Task GetChangesAsync_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Items.GetChangesAsync(appTestData.ItemId);

            AssertHelpers.AssertSuccess(result);
            AssertHelpers.AssertPagedHasResults(result.Value);
        }
    }
    
    [Fact]
    public async Task GetAppPriceListAsync_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Items.GetAppPriceListAsync(appTestData.AppId);

            AssertHelpers.AssertSuccess(result);
            Assert.NotEmpty(result.Value.Items);
        }
    }
}