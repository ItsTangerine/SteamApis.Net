using SteamApis.Net.Tests.Helpers;

namespace SteamApis.Net.Tests.Integration.Steam;

[Collection("SteamApps")]
public sealed class SteamAppsIntegrationTests(IntegrationFixture fx) : IClassFixture<IntegrationFixture>
{
    [Fact]
    public async Task ListAppsAsync_ReturnsPage()
    {
        var result = await fx.Steam.Apps.ListAsync();

        AssertHelpers.AssertSuccess(result);
        AssertHelpers.AssertPagedHasResults(result.Value);
    }

    [Fact]
    public async Task GetPlayerCountsAsync_ReturnsNonNegativeCount()
    {
        var result = await fx.Steam.Apps.GetPlayerCountsAsync();

        AssertHelpers.AssertSuccess(result);
        Assert.True(result.Value.Results?[0].Meta?.PlayerCount >= 0,
            "Player count should be non-negative");
    }

    [Fact]
    public async Task GetDetailsAsync_ReturnsNameAndId()
    {
        var result = await fx.Steam.Apps.GetDetailsAsync(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        Assert.Equal(fx.AppId, result.Value.AppId);
        Assert.False(string.IsNullOrWhiteSpace(result.Value.Name),
            "AppDetails.Name should be populated");
    }
    
    [Fact]
    public async Task GetChangesAsync_NotEmpty()
    {
        var result = await fx.Steam.Apps.GetChangesAsync(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        Assert.True(result.Value.Results?.Count > 0, "AppChanges should contain at least one change");
    }
    
    [Fact]
    public async Task GetGlobalAchievementsAsync_NotEmpty()
    {
        var result = await fx.Steam.Apps.GetGlobalAchievementsAsync(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        Assert.NotEmpty(result.Value);
    }

    [Fact]
    public async Task GetNewsAsync_Succeeds()
    {
        var result = await fx.Steam.Apps.GetNewsAsync(fx.AppId);

        AssertHelpers.AssertSuccess(result);
    }
    
    [Fact]
    public async Task GetSchemaAsync_Succeeds()
    {
        var result = await fx.Steam.Apps.GetSchemaAsync(fx.AppId);

        AssertHelpers.AssertSuccess(result);
    }

    [Fact]
    public async Task GetStoreRankingsAsync_ReturnsPage()
    {
        var result = await fx.Steam.Apps.GetStoreRankingsAsync();

        AssertHelpers.AssertSuccess(result);
    }
    
    [Fact]
    public async Task GetReviewsAsync_ReturnsPage()
    {
        var result = await fx.Steam.Apps.GetReviewsAsync(fx.AppId);

        AssertHelpers.AssertSuccess(result);
        AssertHelpers.AssertPagedHasResults(result.Value);
    }
}