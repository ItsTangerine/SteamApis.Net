using SteamApis.Net.Extensions;
using SteamApis.Net.Http;
using SteamApis.Net.Models.Legacy.Market.App;
using SteamApis.Net.Models.Legacy.Market.Apps;
using SteamApis.Net.Models.Legacy.Market.AssetInfos;
using SteamApis.Net.Models.Legacy.Market.Cards;
using SteamApis.Net.Models.Legacy.Market.Descriptions;
using SteamApis.Net.Models.Legacy.Market.Histograms;
using SteamApis.Net.Models.Legacy.Market.Item;
using SteamApis.Net.Models.Legacy.Market.Items;
using SteamApis.Net.Models.Legacy.Market.Stats;
using SteamApis.Net.Models.Legacy.Steam.Games;
using SteamApis.Net.Models.Legacy.Steam.Inventory;
using SteamApis.Net.Models.Legacy.Steam.Profile;
using SteamApis.Net.Models.Legacy.Steam.Summary;
using SteamApis.Net.Models.Legacy.Steam.Vanity;
using SteamApis.Net.Models.Response;

namespace SteamApis.Net.Clients.Steam;

public sealed class LegacyApi
{
    private readonly ApiConnection _connection;
    private readonly string _apiKey;

    internal LegacyApi(ApiConnection connection, string apiKey)
    {
        _connection = connection;
        _apiKey = apiKey;
    }

    /// <summary>
    /// Fetch Steam user inventories with rate-limit bypass. Returns items, descriptions, and asset details.
    /// </summary>
    /// <param name="steamId">The SteamID64 identifier of the user who's inventory you want to fetch.</param>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="contextId">Context identifier for the application which contents you want to receive from the user's inventory. For most games, the context ID is <c>2</c>. If you're unsure, use the /steam/profile endpoint which returns available contexts for each application.</param>
    /// <param name="legacy"></param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <remarks>This endpoint fetches Steam's inventory endpoint through a pool of proxies giving us the ability to bypass rate-limiting. Returned data is exactly what Steam returns to us without caching.</remarks>
    public Task<ApiResult<InventoryResponse>> GetUserSteamInventory(string steamId, int appId, int contextId, bool legacy = false, CancellationToken ct = default)
    {
        var url = ApiConnection.BuildUrl($"/steam/inventory/{steamId}/{appId}/{contextId}", [("legacy", legacy ? "1" : null), ("api_key", _apiKey)]);
        return _connection.GetFlatAsync<InventoryResponse>(url, ct);
    }

    /// <summary>
    /// Get Steam user profile data including online status, privacy settings, and inventory contexts.
    /// </summary>
    /// <param name="steamId">The SteamID64 identifier of the user who's profile you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Detailed information about the user and its inventory contexts.</returns>
    public Task<ApiResult<SteamProfileResponse>> GetUserSteamProfile(string steamId, CancellationToken ct = default)
        => _connection.GetFlatAsync<SteamProfileResponse>(ApiConnection.BuildUrl($"/steam/profile/{steamId}", [("api_key", _apiKey)]), ct);

    /// <summary>
    /// Resolve Steam vanity URLs to SteamID64. Convert custom profile URLs to numeric identifiers.
    /// </summary>
    /// <param name="vanityName">The vanity URL name to resolve (e.g. <c>pepzwee</c> from <c>steamcommunity.com/id/pepzwee</c>).</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <remarks>This endpoint resolves a Steam vanity URL name to a SteamID64. Vanity URLs are custom profile URLs that users can set (e.g. steamcommunity.com/id/pepzwee).</remarks>
    public Task<ApiResult<SteamVanityResponse>> GetUserSteamVanity(string vanityName, CancellationToken ct = default)
        => _connection.GetFlatAsync<SteamVanityResponse>(ApiConnection.BuildUrl($"/steam/profile/vanity/{vanityName}", [("api_key", _apiKey)]), ct);

    /// <summary>
    /// Get detailed Steam profile data via official API including badges, XP, and account information.
    /// </summary>
    /// <param name="steamId">The SteamID64 identifier of the user whose summary you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Comprehensive user information including badges and XP data.</returns>
    public Task<ApiResult<SteamSummaryResponse>> GetUserSteamSummary(string steamId, CancellationToken ct = default)
       => _connection.GetFlatAsync<SteamSummaryResponse>(ApiConnection.BuildUrl($"/steam/profile/{steamId}/summary", [("api_key", _apiKey)]), ct);

    /// <summary>
    /// Get a list of games owned by a Steam user including playtime statistics.
    /// </summary>
    /// <param name="steamId">The SteamID64 identifier of the user whose game library you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>A list of games owned by the specified user. The user's game library must be set to public for this endpoint to return data.</returns>
    public Task<ApiResult<SteamGamesResponse>> GetUserSteamGames(string steamId, CancellationToken ct = default)
        => _connection.GetFlatAsync<SteamGamesResponse>(ApiConnection.BuildUrl($"/steam/profile/{steamId}/games", [("api_key", _apiKey)]), ct);

    /// <summary>
    /// Get Steam market statistics including total monitored items, spending data, and sales counts.
    /// </summary>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Market statistics data.</returns>
    public Task<ApiResult<GlobalStatsResponse>> GetMarketStats(CancellationToken ct = default)
        => _connection.GetFlatAsync<GlobalStatsResponse>(ApiConnection.BuildUrl($"/market/stats", [("api_key", _apiKey)]), ct);

    /// <summary>
    /// Get detailed information about a specific Steam application including pricing, categories, and metadata.
    /// </summary>
    /// <param name="appId">Identifier of the application which you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Detailed data about any app in our database.</returns>
    public Task<ApiResult<SteamAppDetailsResponse>> GetSingleApp(int appId, CancellationToken ct = default)
        => _connection.GetFlatAsync<SteamAppDetailsResponse>(ApiConnection.BuildUrl($"/market/app/{appId}", [("api_key", _apiKey)]), ct);

    /// <summary>
    /// Get a list of all Steam applications in the SteamApis database with basic metadata.
    /// </summary>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>A list of all Steam applications in the SteamApis database with basic metadata.</returns>
    public Task<ApiResult<SteamAppDetailsShortResponse[]>> GetAllApps(CancellationToken ct = default)
        => _connection.GetFlatAsync<SteamAppDetailsShortResponse[]>(ApiConnection.BuildUrl($"/market/apps", [("api_key", _apiKey)]), ct);
    
    /// <summary>
    /// Get detailed market data for a specific Steam item including price history and buy/sell orders.
    /// </summary>
    /// <param name="appId">Identifier of the application which item you want to fetch.</param>
    /// <param name="marketHashName">The <c>market_hash_name</c> of the item you want to fetch (e.g. <c>AK-47 | Redline (Field-Tested)</c>).</param>
    /// <param name="medianHistoryDays">How many median prices to return in a single response. Default is <c>15</c>.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Detailed data about any item in SteamApis database.</returns>
    public Task<ApiResult<SteamMarketItemResponse>> GetSingleItem(int appId, string marketHashName, int? medianHistoryDays = null, CancellationToken ct = default)
        => _connection.GetFlatAsync<SteamMarketItemResponse>(ApiConnection.BuildUrl($"/market/item/{appId}/{marketHashName}", [("median_history_days", medianHistoryDays?.ToString()), ("api_key", _apiKey)]), ct);

    /// <summary>
    /// Get market data for all monitored items in a Steam application including prices and sales volume.
    /// </summary>
    /// <param name="appId">Identifier of the application which items you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Details for all monitored items in our database that belong to the specified application. If the item has no sales history its shown prices will be <c>0</c>.</returns>
    public Task<ApiResult<AppItemsResponse>> GetAllItems(int appId, CancellationToken ct = default)
        => _connection.GetFlatAsync<AppItemsResponse>(ApiConnection.BuildUrl($"/market/items/{appId}", [("api_key", _apiKey)]), ct);

    /// <summary>
    /// Get price details for all monitored Steam trading cards including card sets and foil variants.
    /// </summary>
    /// <param name="appId">Identifier of the application which items you want to fetch.</param>
    /// <param name="compactValue">Compact value for the request.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Dictionary of item names and their prices.</returns>
    /// <remarks>
    /// Supported compact values:
    /// <list type="bullet">
    /// <item><description><c>latest</c></description></item>
    /// <item><description><c>min</c></description></item>
    /// <item><description><c>avg</c></description></item>
    /// <item><description><c>max</c></description></item>
    /// <item><description><c>mean</c></description></item>
    /// <item><description><c>safe</c></description></item>
    /// <item><description><c>safe_ts.last_24h</c></description></item>
    /// <item><description><c>safe_ts.last_7d</c></description></item>
    /// <item><description><c>safe_ts.last_30d</c></description></item>
    /// <item><description><c>safe_ts.last_90d</c></description></item>
    /// <item><description><c>unstable</c></description></item>
    /// <item><description><c>unstable_reason</c> -  (Default: safe)</description></item>
    /// </list>
    /// </remarks>
    public Task<ApiResult<Dictionary<string, double>>> GetAllItemsCompact(int appId, CompactValue compactValue = CompactValue.Safe, CancellationToken ct = default)
    {
        var url = ApiConnection.BuildUrl($"/market/items/{appId}", [
            ("format", "compact"),
            ("median_history_days", compactValue != CompactValue.Safe ? compactValue.GetEnumMemberValue() : null),
            ("api_key", _apiKey)
        ]);
        
        return _connection.GetFlatAsync<Dictionary<string, double>>(url, ct);
    }

    /// <summary>
    /// Get price details for all monitored Steam trading cards including card sets and foil variants.
    /// </summary>
    /// <param name="ct">Cancellation token for the request</param>
    /// <returns>Details for all monitored Steam cards in our database. If the item has no sales history its shown prices will be <c>0</c>.</returns>
    public Task<ApiResult<SteamCardSetResponse>> GetAllCards(CancellationToken ct = default)
        =>  _connection.GetFlatAsync<SteamCardSetResponse>(ApiConnection.BuildUrl($"/market/items/cards", [("api_key", _apiKey)]), ct);

    /// <summary>
    /// Get market description metadata for items including icons, actions, and detailed item information.
    /// </summary>
    /// <param name="appId">Identifier of the application which item descriptions you want to fetch.</param>
    /// <param name="page">The page number to fetch. Default is <c>1</c>.</param>
    /// <param name="ct">Cancellation token for the request</param>
    /// <returns>Market description info for all items that belong to the specified application. The response is paginated and includes detailed asset information such as icons, actions, and item descriptions.</returns>
    public Task<ApiResult<MarketDescriptionsResponse>> GetMarketDescriptions(int appId, int page = 1, CancellationToken ct = default)
    {
        var url = ApiConnection.BuildUrl($"/market/items/{appId}/descriptions", [
            ("page", page > 1 ? page.ToString() : null),
            ("api_key", _apiKey)
        ]);
        
        return _connection.GetFlatAsync<MarketDescriptionsResponse>(url, ct);
    }

    /// <summary>
    /// Get buy and sell order data for all items in a Steam application. View highest buy orders and lowest sell orders.
    /// </summary>
    /// <param name="appId">Identifier of the application which item histograms you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request</param>
    /// <returns>Buy and sell order data (histogram information) for all monitored items that belong to the specified application. This provides a quick overview of the current highest buy orders and lowest sell orders across all items.</returns>
    public Task<ApiResult<MarketHistogramData[]>> GetMarketHistograms(int appId, CancellationToken ct = default)
        => _connection.GetFlatAsync<MarketHistogramData[]>(ApiConnection.BuildUrl($"/market/items/{appId}/histograms", [("api_key", _apiKey)]), ct);
    
    /// <summary>
    /// Get detailed asset information for items including tags, icons, descriptions, and trade/market status.
    /// </summary>
    /// <param name="appId">Identifier of the application which item asset infos you want to fetch.</param>
    /// <param name="cursor">The cursor for pagination. Use the cursor value from the previous response to fetch the next page of results.</param>
    /// <param name="ct">Cancellation token for the request</param>
    /// <returns>All the asset information for items that belong to the specified application. The response is paginated using cursor-based pagination and includes detailed item metadata such as icons, tags, descriptions, and trade/market status.</returns>
    public Task<ApiResult<MarketAssetInfosResponse>> GetMarketAssetInfos(int appId, string? cursor = null, CancellationToken ct = default)
    {
        var url = ApiConnection.BuildUrl($"/market/items/{appId}/assetinfos", [("cursor", cursor), ("api_key", _apiKey)]);
        return _connection.GetFlatAsync<MarketAssetInfosResponse>(url, ct);
    }
    
    /// <summary>
    /// Get the Steam CDN image URL for a specific item by its market hash name.
    /// </summary>
    /// <param name="appId">Identifier of the application which item image you want to fetch.</param>
    /// <param name="marketHashName">The <c>market_hash_name</c> of the item you want to fetch (e.g. <c>AK-47 | Redline (Field-Tested)</c>).</param>
    /// <param name="ct">Cancellation token for the request</param>
    /// <returns>The Steam CDN image URL for the specified item.</returns>
    public Task<ApiResult<byte[]>> GetImage(int appId, string marketHashName, CancellationToken ct = default)
        => _connection.GetBytesAsync($"/image/item/{appId}/{marketHashName}", ct);

    /// <summary>
    /// Get all item image URLs for a Steam application. Returns a mapping of market hash names to CDN URLs.
    /// </summary>
    /// <param name="appId">Identifier of the application for which you want to retrieve item images.</param>
    /// <param name="ct">Cancellation token for the request</param>
    /// <returns>A dictionary mapping market hash names to Steam CDN image URLs for the specified application.</returns>
    public Task<ApiResult<Dictionary<string, string>>> GetImages(int appId, CancellationToken ct = default)
        => _connection.GetFlatAsync<Dictionary<string, string>>($"/image/items/{appId}", ct);
}