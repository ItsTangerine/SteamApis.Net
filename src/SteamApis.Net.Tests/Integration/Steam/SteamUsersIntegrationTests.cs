using SteamApis.Net.Tests.Helpers;

namespace SteamApis.Net.Tests.Integration.Steam;

[Collection("SteamUsers")]
public sealed class SteamUsersIntegrationTests(IntegrationFixture fx) : IClassFixture<IntegrationFixture>
{
    [Fact]
    public async Task GetAsync_ReturnsPopulatedUser()
    {
        var result = await fx.Steam.Users.GetAsync(fx.SteamId);

        AssertHelpers.AssertSuccess(result);
        Assert.False(string.IsNullOrWhiteSpace(result.Value.SteamId),
            "SteamUser.SteamId should be populated");
    }

    [Fact]
    public async Task GetGroupsAsync_Succeeds()
    {
        var result = await fx.Steam.Users.GetGroupsAsync(fx.SteamId);

        AssertHelpers.AssertSuccess(result);
    }

    [Fact]
    public async Task GetInventoryAsync_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Users.GetInventoryAsync(fx.SteamId, appTestData.AppId);

            AssertHelpers.AssertSuccess(result);
        }
    }

    [Fact]
    public async Task GetBadgesAsync_Succeeds()
    {
        var result = await fx.Steam.Users.GetBadgesAsync(fx.SteamId);

        AssertHelpers.AssertSuccess(result);
    }

    [Fact]
    public async Task GetGamesAsync_Succeeds()
    {
        var result = await fx.Steam.Users.GetGamesAsync(fx.SteamId);

        AssertHelpers.AssertSuccess(result);
    }

    [Fact]
    public async Task GetBansAsync_Succeeds()
    {
        var result = await fx.Steam.Users.GetBansAsync(fx.SteamId);

        AssertHelpers.AssertSuccess(result);
    }

    [Fact]
    public async Task ResolveVanityAsync_ReturnsSteamId()
    {
        var result = await fx.Steam.Users.ResolveVanityAsync(fx.VanityUrl);

        AssertHelpers.AssertSuccess(result);
        Assert.False(string.IsNullOrWhiteSpace(result.Value.SteamId),
            "Resolved SteamID should not be empty");
    }
    
    [Fact]
    public async Task GetRecentlyPlayedAsync_Succeeds()
    {
        var result = await fx.Steam.Users.GetRecentlyPlayedAsync(fx.SteamId);

        AssertHelpers.AssertSuccess(result);
    }
    
    [Fact]
    public async Task GetGameAchievementsAsync_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Users.GetGameAchievementsAsync(fx.SteamId, appTestData.AppId);

            AssertHelpers.AssertSuccess(result);
        }
    }
    
    [Fact]
    public async Task GetGameStatsAsync_Succeeds()
    {
        foreach (var appTestData in fx.AppData)
        {
            var result = await fx.Steam.Users.GetGameStatsAsync(fx.SteamId, appTestData.AppId);

            AssertHelpers.AssertSuccess(result);
        }
    }
    
    [Fact]
    public async Task GetFriendsAsync_Succeeds()
    {
        var result = await fx.Steam.Users.GetFriendsAsync(fx.SteamId);

        AssertHelpers.AssertSuccess(result);
    }
}