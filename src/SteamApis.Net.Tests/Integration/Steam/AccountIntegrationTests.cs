using SteamApis.Net.Tests.Helpers;

namespace SteamApis.Net.Tests.Integration.Steam;

[Collection("SteamAccount")]
public sealed class AccountIntegrationTests(IntegrationFixture fx) : IClassFixture<IntegrationFixture>
{
    [Fact]
    public async Task Account_GetDetailsAsync_ReturnsPopulatedUser()
    {
        var result = await fx.Steam.Account.GetDetailsAsync();

        AssertHelpers.AssertSuccess(result);
        Assert.True(result.Value.Balance >= 0,
            "Account.Balance should be non-negative");
    }
}