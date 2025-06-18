using SteamApis.Net.Entities.Response.Market.App;
using SteamApis.Net.Entities.Response.Market.Apps;
using SteamApis.Net.Entities.Response.Market.Cards;
using SteamApis.Net.Entities.Response.Market.Item;
using SteamApis.Net.Entities.Response.Market.Items;
using SteamApis.Net.Entities.Response.Market.Stats;
using SteamApis.Net.Entities.Response.Steam.Inventory;
using SteamApis.Net.Entities.Response.Steam.Profile;

namespace SteamApis.Net.Services;

public interface ISteamApisClient
{
    /// <summary>
    /// Returns response of Steam's inventory endpoint through a pool of proxies giving us the ability to bypass rate-limiting. Returned data is exactly what Steam returns to us without caching.
    /// </summary>
    /// <param name="steamId">The SteamID64 identifier of the user who's inventory you want to fetch.</param>
    /// <param name="appId">Identifier of the application which contents you want to receive from the user's inventory.</param>
    /// <param name="contextId">Context identifier for the application which contents you want to receive from the user's inventory (e.g., 2 for CS:GO items).</param>
    /// <param name="legacy">Sets the value to whether to use the old deprecated inventory endpoint.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="ValueTask{InventoryResponse}"/> representing the asynchronous operation containing the user's inventory.</returns>
    ValueTask<InventoryResponse> GetUserSteamInventory(string steamId, int appId, int contextId, bool legacy = false, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns response of Steam's profile endpoint, detailed information about the user and its inventory contexts.
    /// </summary>
    /// <param name="steamId">The SteamID64 identifier of the user who's inventory you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="ValueTask{SteamProfileResponse}"/> representing the asynchronous operation containing the user's Steam profile data.</returns>
    ValueTask<SteamProfileResponse> GetUserSteamProfile(string steamId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns the data that https://steamapis.com display on the frontpage.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="ValueTask{GlobalStatsResponse}"/> representing the asynchronous operation containing the global stats data.</returns>
    ValueTask<GlobalStatsResponse> GetMarketStats(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns detailed data about any app in https://steamapis.com database.
    /// </summary>
    /// <param name="appId">Identifier of the application which you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="ValueTask{SteamAppDetailsResponse}"/> representing the asynchronous operation that contains the application's detailed information. </returns>
    ValueTask<SteamAppDetailsResponse> GetSingleApp(int appId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns all apps in https://steamapis.com database.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="ValueTask{SteamAppDetailsShortResponse}"/> representing the asynchronous operation that contains all https://steamapis.com stored applications details. </returns>
    ValueTask<SteamAppDetailsShortResponse[]> GetAllApps(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns detailed data about any item in https://steamapis.com database.
    /// </summary>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="marketHashName">The market_hash_name of the item you want to fetch.</param>
    /// <param name="medianHistoryDays">How many median prices to return in a single response. Default is 15.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="ValueTask{SteamMarketItemResponse}"/> that represents the asynchronous operation containing item market data.</returns>
    ValueTask<SteamMarketItemResponse> GetSingleItem(int appId, string marketHashName, int medianHistoryDays = 15, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns price details for all monitored items in https://steamapis.com database that belong to the specified application. If the item has no sales history its shown prices will be 0.
    /// </summary>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="ValueTask{AppItemsResponse}"/> that represents the asynchronous operation containing all items market data for specific app identifier.</returns>
    ValueTask<AppItemsResponse> GetAllItems(int appId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns a compact dictionary of all item prices for the specified application using the selected compact value type.
    /// </summary>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="compactValue">The pricing metric to use for each item (e.g., latest, min, avg, safe). Default is <see cref="CompactValue.Safe"/>.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="ValueTask{TResult}"/> containing a dictionary where keys are market hash names and values are prices.</returns>
    ValueTask<Dictionary<string, double>> GetAllItemsCompact(int appId, CompactValue compactValue = CompactValue.Safe, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns price details for all monitored Steam cards in https://steamapis.com database. If the item has no sales history its shown prices will be 0.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="ValueTask{SteamCardSetResponse}"/> containing an array of Steam cards and their pricing details.</returns>
    ValueTask<SteamCardSetResponse> GetAllCards(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Redirects to the image of specified item if it exists in https://steamapis.com database, else an error is returned.
    /// </summary>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="marketHashName">The market_hash_name of the item you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="ValueTask{TResult}"/> containing a byte array.</returns>
    ValueTask<byte[]> GetImage(int appId, string marketHashName, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns all item images in https://steamapis.com database that belong to the specified application.
    /// </summary>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="ValueTask{TResult}"/> containing a dictionary where keys are market hash names and values are image links.</returns>
    ValueTask<Dictionary<string, string>> GetImages(int appId, CancellationToken cancellationToken = default);
}