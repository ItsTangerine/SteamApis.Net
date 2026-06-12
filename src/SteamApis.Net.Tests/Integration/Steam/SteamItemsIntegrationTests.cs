using SteamApis.Net.Tests.Helpers;

namespace SteamApis.Net.Tests.Integration.Steam;

[Collection("SteamItems")]
public sealed class SteamItemsIntegrationTests(IntegrationFixture fx) : IClassFixture<IntegrationFixture>
{
    [Fact]
    public async Task ListAsync_ReturnsPage()
    {
        var result = await fx.Steam.Items.ListAsync(appId: fx.AppId);

        AssertHelpers.AssertSuccess(result);
        AssertHelpers.AssertPagedHasResults(result.Value);
    }

    [Fact]
    public async Task GetDetailsAsync_ReturnsNameAndAppId()
    {
        var result = await fx.Steam.Items.GetDetailsAsync(fx.AppId, fx.MarketHashName);

        AssertHelpers.AssertSuccess(result);
        Assert.False(string.IsNullOrWhiteSpace(result.Value.Item.Id),
            "ItemDetails.Id should be populated");
        Assert.True(result.Value.PriceHistory?.Data.Count > 0,
            "ItemDetails.PriceHistory should contain at least one price");
    }

    [Fact]
    public async Task GetMetaAsync_ReturnsName()
    {
        var result = await fx.Steam.Items.GetMetaAsync(fx.ItemId);

        AssertHelpers.AssertSuccess(result);
        Assert.True(result.Value.AppId != 0,
            "ItemMeta.Name should be populated");
    }

    [Fact]
    public async Task GetHistogramsAsync_Succeeds()
    {
        var result = await fx.Steam.Items.GetHistogramsAsync(fx.ItemId);

        AssertHelpers.AssertSuccess(result);
        AssertHelpers.AssertPagedHasResults(result.Value);
    }

    [Fact]
    public async Task GetPricesAsync_ReturnsNonEmptyList()
    {
        var result = await fx.Steam.Items.GetPricesAsync(fx.ItemId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value);
        Assert.All(result.Value, p =>
            Assert.True(p.Price >= 0, "Price should be non-negative"));
    }
    
    [Fact]
    public async Task GetChangesAsync_Succeeds()
    {
        var result = await fx.Steam.Items.GetChangesAsync(fx.ItemId);

        AssertHelpers.AssertSuccess(result);
        AssertHelpers.AssertPagedHasResults(result.Value);
    }
    
    [Fact]
    public async Task GetAppPriceListAsync_Succeeds()
    {
        var result = await fx.Steam.Items.GetAppPriceListAsync(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value.Items);
    }
}