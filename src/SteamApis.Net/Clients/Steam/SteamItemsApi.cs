using SteamApis.Net.Http;
using SteamApis.Net.Models.Common;
using SteamApis.Net.Models.Items;
using SteamApis.Net.Models.Response;
using SteamApis.Net.Models.SteamApis;

namespace SteamApis.Net.Clients.Steam;

public sealed class SteamItemsApi
{
    private readonly ApiConnection _connection;

    internal SteamItemsApi(ApiConnection connection) => _connection = connection;
    
    /// <summary>
    /// Get a paginated list of all Steam market items tracked by SteamApis with optional filtering.
    /// </summary>
    /// <param name="appId">Filter items by appId.</param>
    /// <param name="cursor">Pagination cursor. Pass the cursor value from a previous response to fetch the next page.</param>
    /// <param name="metaUpdatedAfter">Filter items whose metadata was updated after this ISO timestamp.</param>
    /// <param name="histogramUpdatedAfter">Filter items whose histogram data was updated after this ISO timestamp.</param>
    /// <param name="priceHistoryUpdatedAfter">Filter items whose price history was updated after this ISO timestamp.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Paginated list of all Steam market items tracked by SteamApis. You can optionally filter items by when their metadata, histogram, or price history was last updated.</returns>
    public Task<ApiResult<PagedApiResponse<MarketItem>>> ListAsync(
        int? appId = null,
        string? cursor = null,
        string? metaUpdatedAfter = null,
        string? histogramUpdatedAfter = null,
        string? priceHistoryUpdatedAfter = null,
        CancellationToken ct = default)
    {
        var url = ApiConnection.BuildUrl("/v2/steam/items",
        [
            ("appId",                    appId?.ToString()),
            ("cursor",                   cursor),
            ("metaUpdatedAfter",         metaUpdatedAfter),
            ("histogramUpdatedAfter",    histogramUpdatedAfter),
            ("priceHistoryUpdatedAfter", priceHistoryUpdatedAfter),
        ]);
        return _connection.GetPagedAsync<MarketItem>(url, ct);
    }
 
    /// <summary>
    /// Get full details for a specific Steam market item including metadata, histogram, and price history.
    /// </summary>
    /// <param name="appId">The Steam application ID the item belongs to.</param>
    /// <param name="marketHashName">The URL-encoded market hash name of the item.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Comprehensive data for a specific Steam market item, including the item record, metadata, latest buy/sell histogram, and price history.</returns>
    public Task<ApiResult<ItemDetails>> GetDetailsAsync(int appId, string marketHashName, CancellationToken ct = default)
        => _connection.GetResultAsync<ItemDetails>($"/v2/steam/items/{appId}/{Uri.EscapeDataString(marketHashName)}", ct);
 
    /// <summary>
    /// Get metadata for a specific Steam market item including images, tags, and trade flags.
    /// </summary>
    /// <param name="itemId">The item document ID (the _id field from the list items or item details endpoint).</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The metadata for a specific item, including images, colors, trade/market flags, descriptions, and tags.</returns>
    public Task<ApiResult<ItemMeta>> GetMetaAsync(string itemId, CancellationToken ct = default)
        => _connection.GetResultAsync<ItemMeta>($"/v2/steam/items/{Uri.EscapeDataString(itemId)}/meta", ct);
 
    /// <summary>
    /// Get paginated buy/sell order histogram snapshots for a specific Steam market item.
    /// </summary>
    /// <param name="itemId">The item document ID (the _id field from the list items or item details endpoint).</param>
    /// <param name="cursor">Pagination cursor. Pass the cursor value from a previous response to fetch the next page.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Paginated list of historical buy/sell order histogram snapshots for a specific item.</returns>
    public Task<ApiResult<PagedApiResponse<ItemHistogram>>> GetHistogramsAsync(string itemId, string? cursor = null, CancellationToken ct = default)
        => _connection.GetPagedAsync<ItemHistogram>(ApiConnection.BuildUrl($"/v2/steam/items/{Uri.EscapeDataString(itemId)}/histograms", [("cursor", cursor)]), ct);
 
    /// <summary>
    /// Get historical price data for a specific Steam market item.
    /// </summary>
    /// <param name="itemId">The item document ID (the _id field from the list items or item details endpoint).</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The historical price data for a specific item, including daily sale prices and quantities.</returns>
    public Task<ApiResult<IReadOnlyList<ItemPricePoint>>> GetPricesAsync(string itemId, CancellationToken ct = default)
        => _connection.GetResultAsync<IReadOnlyList<ItemPricePoint>>($"/v2/steam/items/{Uri.EscapeDataString(itemId)}/prices", ct);
    
    /// <summary>
    /// Get a paginated changelog of tracked changes for a specific Steam market item.
    /// </summary>
    /// <param name="itemId">The item document ID (the _id field from the list items or item details endpoint).</param>
    /// <param name="cursor">Pagination cursor. Pass the cursor value from a previous response to fetch the next page.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Paginated list of tracked changes for a specific item. Changes are recorded when item data (metadata, locale information, etc.) is modified.</returns>
    public Task<ApiResult<PagedApiResponse<ChangeLogEntry>>> GetChangesAsync(string itemId, string? cursor = null, CancellationToken ct = default)
        => _connection.GetPagedAsync<ChangeLogEntry>(ApiConnection.BuildUrl($"/v2/steam/items/{Uri.EscapeDataString(itemId)}/changes", [("cursor", cursor)]), ct);

    /// <summary>
    /// Get a full price list for all market items of a given Steam app, redirecting to a pre-generated file whose contents depend on your history plan.
    /// </summary>
    /// <param name="appId">The Steam application ID whose item price list you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>A comprehensive pre-generated price list for every market item tracked for a given Steam app — including current price summaries, volume, order book depth, signals, and flags. It's intended for bulk consumers (e.g. syncing a local price cache for an entire app's market).</returns>
    /// <remarks>
    /// The endpoint redirects (HTTP 302) to a pre-generated JSON file hosted on SteamApis' CDN. The exact contents of that file depend on your active history plan — plans with more history expose deeper prices windows (for example, 180d and all). Your HTTP client should follow redirects automatically.
    /// </remarks>
    public Task<ApiResult<MarketSnapshot>> GetAppPriceListAsync(int appId, CancellationToken ct = default)
    {
        return _connection.GetFlatAsync<MarketSnapshot>($"/v2/steam/items/{appId}/list", ct);
    }

}