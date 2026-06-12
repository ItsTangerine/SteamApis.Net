using SteamApis.Net.Clients;

namespace SteamApis.Net.Services;

public interface ISteamApisClient
{
    /// <summary>Steam API endpoints (users, apps, items).</summary>
    SteamApiClient Steam { get; }
 
    /// <summary>Third-party Marketplace Data API endpoints.</summary>
    MarketPlaceApiClient MarketPlace { get; }
}