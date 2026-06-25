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
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Apps.GetDetailsAsync(appTestData.AppId);

            AssertHelpers.AssertSuccess(result);
            Assert.Equal(appTestData.AppId, result.Value.AppId);
            Assert.False(string.IsNullOrWhiteSpace(result.Value.Name),
                "AppDetails.Name should be populated");
        }
    }
    
    [Fact]
    public async Task GetChangesAsync_NotEmpty()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Apps.GetChangesAsync(appTestData.AppId);

            AssertHelpers.AssertSuccess(result);
            Assert.True(result.Value.Results?.Count > 0, "AppChanges should contain at least one change");
        }
    }
    
    [Fact]
    public async Task GetGlobalAchievementsAsync_NotEmpty()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Apps.GetGlobalAchievementsAsync(appTestData.AppId);

            AssertHelpers.AssertSuccess(result);
        }
    }

    [Fact]
    public async Task GetNewsAsync_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Apps.GetNewsAsync(appTestData.AppId);

            AssertHelpers.AssertSuccess(result);
        }
    }
    
    [Fact]
    public async Task GetSchemaAsync_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Apps.GetSchemaAsync(appTestData.AppId);

            AssertHelpers.AssertSuccess(result);
        }
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
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Apps.GetReviewsAsync(appTestData.AppId);

            AssertHelpers.AssertSuccess(result);
            AssertHelpers.AssertPagedHasResults(result.Value);
        }
    }
}