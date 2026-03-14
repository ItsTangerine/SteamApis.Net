using SteamApis.Net.Entities.Response;
using SteamApis.Net.Entities.Response.Market.App;
using SteamApis.Net.Entities.Response.Market.Apps;
using SteamApis.Net.Entities.Response.Market.AssetInfos;
using SteamApis.Net.Entities.Response.Market.Cards;
using SteamApis.Net.Entities.Response.Market.Descriptions;
using SteamApis.Net.Entities.Response.Market.Histograms;
using SteamApis.Net.Entities.Response.Market.Item;
using SteamApis.Net.Entities.Response.Market.Items;
using SteamApis.Net.Entities.Response.Market.Stats;
using SteamApis.Net.Entities.Response.Steam.Games;
using SteamApis.Net.Entities.Response.Steam.Inventory;
using SteamApis.Net.Entities.Response.Steam.Profile;
using SteamApis.Net.Entities.Response.Steam.Summary;
using SteamApis.Net.Entities.Response.Steam.Vanity;

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
    /// <returns>A <see cref="Task{InventoryResponse}"/> representing the asynchronous operation containing the user's inventory.</returns>
    Task<ApiResult<InventoryResponse>> GetUserSteamInventory(string steamId, int appId, int contextId, bool legacy = false, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns response of Steam's profile endpoint, detailed information about the user and its inventory contexts.
    /// </summary>
    /// <param name="steamId">The SteamID64 identifier of the user who's inventory you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task{SteamProfileResponse}"/> representing the asynchronous operation containing the user's Steam profile data.</returns>
    Task<ApiResult<SteamProfileResponse>> GetUserSteamProfile(string steamId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Resolve Steam vanity URLs to SteamID64. Convert custom profile URLs to numeric identifiers.
    /// </summary>
    /// <param name="vanityName">The vanity URL name to resolve (e.g. pepzwee from steamcommunity.com/id/pepzwee).</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task{SteamVanityResponse}"/> representing the asynchronous operation containing matching vanity url to a SteamID64.</returns>
    Task<ApiResult<SteamVanityResponse>> GetUserSteamVanity(string vanityName, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get detailed Steam profile data via official API including badges, XP, and account information.
    /// </summary>
    /// <param name="steamId">The SteamID64 identifier of the user whose profile you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task{SteamSummaryResponse}"/> representing the asynchronous operation containing comprehensive user information including badges and XP data.</returns>
    Task<ApiResult<SteamSummaryResponse>> GetUserSteamSummary(string steamId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get a list of games owned by a Steam user including playtime statistics.
    /// </summary>
    /// <param name="steamId">The SteamID64 identifier of the user whose game library you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task{SteamGamesResponse}"/> representing the asynchronous operation containing a list of games owned by the specified user.</returns>
    Task<ApiResult<SteamGamesResponse>> GetUserSteamGames(string steamId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns the data that https://steamapis.com display on the frontpage.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A <see cref="Task{GlobalStatsResponse}"/> representing the asynchronous operation containing the global stats data.</returns>
    Task<ApiResult<GlobalStatsResponse>> GetMarketStats(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns detailed data about any app in https://steamapis.com database.
    /// </summary>
    /// <param name="appId">Identifier of the application which you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="Task{SteamAppDetailsResponse}"/> representing the asynchronous operation that contains the application's detailed information. </returns>
    Task<ApiResult<SteamAppDetailsResponse>> GetSingleApp(int appId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns all apps in https://steamapis.com database.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="Task{SteamAppDetailsShortResponse}"/> representing the asynchronous operation that contains all https://steamapis.com stored applications details. </returns>
    Task<ApiResult<SteamAppDetailsShortResponse[]>> GetAllApps(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns detailed data about any item in https://steamapis.com database.
    /// </summary>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="marketHashName">The market_hash_name of the item you want to fetch.</param>
    /// <param name="medianHistoryDays">How many median prices to return in a single response. Default is 15.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="Task{SteamMarketItemResponse}"/> that represents the asynchronous operation containing item market data.</returns>
    Task<ApiResult<SteamMarketItemResponse>> GetSingleItem(int appId, string marketHashName, int medianHistoryDays = 15, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns price details for all monitored items in https://steamapis.com database that belong to the specified application. If the item has no sales history its shown prices will be 0.
    /// </summary>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="Task{AppItemsResponse}"/> that represents the asynchronous operation containing all items market data for specific app identifier.</returns>
    Task<ApiResult<AppItemsResponse>> GetAllItems(int appId, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns a compact dictionary of all item prices for the specified application using the selected compact value type.
    /// </summary>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="compactValue">The pricing metric to use for each item (e.g., latest, min, avg, safe). Default is <see cref="CompactValue.Safe"/>.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="Task{TResult}"/> containing a dictionary where keys are market hash names and values are prices.</returns>
    Task<ApiResult<Dictionary<string, double>>> GetAllItemsCompact(int appId, CompactValue compactValue = CompactValue.Safe, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns price details for all monitored Steam cards in https://steamapis.com database. If the item has no sales history its shown prices will be 0.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="Task{SteamCardSetResponse}"/> containing an array of Steam cards and their pricing details.</returns>
    Task<ApiResult<SteamCardSetResponse>> GetAllCards(CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get market description metadata for items including icons, actions, and detailed item information.
    /// </summary>
    /// <param name="appId">Identifier of the application which item descriptions you want to fetch.</param>
    /// <param name="page">The page number to fetch. Default is 1.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="Task{MarketDescriptionsResponse}"/> that represents the asynchronous operation containing paginated response with detailed asset information such as icons, actions, and item descriptions.</returns>
    Task<ApiResult<MarketDescriptionsResponse>> GetMarketDescriptions(int appId, int page = 1, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Get buy and sell order data for all items in a Steam application. View highest buy orders and lowest sell orders.
    /// </summary>
    /// <param name="appId">Identifier of the application which item histograms you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="Task{TResult}"/> that represents the asynchronous operation containing buy and sell order data (histogram information) for all monitored items that belong to the specified application.</returns>
    Task<ApiResult<MarketHistogramData[]>> GetMarketHistograms(int appId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get detailed asset information for items including tags, icons, descriptions, and trade/market status.
    /// </summary>
    /// <param name="appId">Identifier of the application which item asset infos you want to fetch.</param>
    /// <param name="cursor">The cursor for pagination. Use the cursor value from the previous response to fetch the next page of results.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="Task{MarketDescriptionsResponse}"/> that represents the asynchronous operation containing all the asset information for items that belong to the specified application.</returns>
    Task<ApiResult<MarketAssetInfosResponse>> GetMarketAssetInfos(int appId, string? cursor = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Redirects to the image of specified item if it exists in https://steamapis.com database, else an error is returned.
    /// </summary>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="marketHashName">The market_hash_name of the item you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="Task{TResult}"/> containing a byte array.</returns>
    Task<ApiResult<byte[]>> GetImage(int appId, string marketHashName, CancellationToken cancellationToken = default);
    
    /// <summary>
    /// Returns all item images in https://steamapis.com database that belong to the specified application.
    /// </summary>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns> A <see cref="Task{TResult}"/> containing a dictionary where keys are market hash names and values are image links.</returns>
    Task<ApiResult<Dictionary<string, string>>> GetImages(int appId, CancellationToken cancellationToken = default);
}