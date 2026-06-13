using SteamApis.Net.Clients.Steam;
using SteamApis.Net.Http;
using SteamApis.Net.Models.Response;

namespace SteamApis.Net.Clients;

/// <summary>
/// Covers all Steam API v2 endpoints.
/// Every method returns <see cref="ApiResult{T}"/>.
/// Base URL: <c>https://api.steamapis.com</c>
/// </summary>
public sealed class SteamApiClient
{
    public SteamApiClient(HttpClient httpClient, string apiKey)
    {
        var connection = new ApiConnection(httpClient);
        Account = new AccountApi(connection);
        Users = new SteamUsersApi(connection);
        Apps = new SteamAppsApi(connection);
        Items = new SteamItemsApi(connection);
        Legacy = new LegacyApi(connection, apiKey);
    }

    /// <summary>Account details endpoints.</summary>
    public AccountApi Account { get; }

    /// <summary>User profiles, friends, bans, inventories.</summary>
    public SteamUsersApi Users { get; }

    /// <summary>App listings, details, news, rankings.</summary>
    public SteamAppsApi Apps { get; }

    /// <summary>Tracked market items, histograms, price history.</summary>
    public SteamItemsApi Items { get; }
    
    /// <summary>Legacy API endpoints.</summary>
    public LegacyApi Legacy { get; }
}