using SteamApis.Net.Http;
using SteamApis.Net.Models.Account;
using SteamApis.Net.Models.Response;

namespace SteamApis.Net.Clients.Steam;

public sealed class AccountApi
{
    private readonly ApiConnection _connection;

    internal AccountApi(ApiConnection connection) => _connection = connection;

    /// <summary>
    /// Get your API account details including balance, overage settings, and per-product subscription info with usage counters.
    /// </summary>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Account details for the authenticated API key, including your remaining balance, overage configuration, and per-product subscription status with cycle-to-date usage.</returns>
    public Task<ApiResult<AccountDetails>> GetDetailsAsync(CancellationToken ct = default)
        => _connection.GetFlatAsync<AccountDetails>("/v2/account", ct);
}