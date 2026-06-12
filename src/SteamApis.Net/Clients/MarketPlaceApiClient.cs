using SteamApis.Net.Http;
using SteamApis.Net.Models.Marketplace;
using SteamApis.Net.Models.Response;

namespace SteamApis.Net.Clients;

/// <summary>
/// Covers all Marketplace Data REST API v2 endpoints.
/// Every method returns <see cref="ApiResult{T}"/> — no exceptions for API errors.
/// Base URL: <c>https://marketplaceapi.steamapis.com</c>
/// </summary>
public sealed class MarketPlaceApiClient(HttpClient httpClient)
{
    private readonly ApiConnection _connection = new(httpClient);

    /// <summary>
    /// Get the list of third-party marketplaces supported by the REST API, including which games each marketplace covers.
    /// </summary>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>the list of marketplaces currently served by the REST API and the games each one covers. This is a static list — for live sales and buy-order availability see https://docs.steamapis.com/market-data/reference.</returns>
    public Task<ApiResult<IReadOnlyList<MarketplaceMeta>>> ListAsync(CancellationToken ct = default)
        => _connection.GetFlatAsync<IReadOnlyList<MarketplaceMeta>>("/v2/marketplaces", ct);
 
    /// <summary>
    /// Search for items by name across marketplaces, returning a lightweight list of matches.
    /// </summary>
    /// <param name="gameCode">Game code (e.g. <c>CS2</c>, <c>Dota2</c>, <c>Rust</c>, <c>TF2</c>).</param>
    /// <param name="query">Search string to match against item names.</param>
    /// <param name="marketplace">Optional marketplace filter. Omit to search across all marketplaces.</param>
    /// <param name="limit">Maximum number of results to return. Defaults to <c>100</c>.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Searches for items by name and returns a lightweight list of matches. Useful for autocomplete and for discovering the exact market name to pass to https://docs.steamapis.com/market-data/rest/items.</returns>
    public Task<ApiResult<IReadOnlyList<MarketplaceSearchResult>>> SearchItemsAsync(
        string gameCode,
        string query,
        string? marketplace = null,
        int? limit = null,
        CancellationToken ct = default)
    {
        var url = ApiConnection.BuildUrl("/v2/items/search",
        [
            ("game",        gameCode),
            ("query",       query),
            ("marketplace", marketplace),
            ("limit",       limit?.ToString()),
        ]);
        return _connection.GetFlatAsync<IReadOnlyList<MarketplaceSearchResult>>(url, ct);
    }
    
    /// <summary>
    /// Fetch a single item from a specific marketplace, including its current offers and open buy orders.
    /// </summary>
    /// <param name="marketplace">Marketplace name (e.g. <c>Buff163</c>). Case-insensitive.</param>
    /// <param name="gameCode">Game code (e.g. <c>CS2</c>, <c>Dota2</c>, <c>Rust</c>, <c>TF2</c>).</param>
    /// <param name="marketHashName">Full item market name (e.g. <c>AK-47 | Redline (Field-Tested)</c>).</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The full data for a single item on a single marketplace, including every currently listed offer and every open buy order.</returns>
    public Task<ApiResult<MarketplaceItem>> GetItemAsync(
        string marketplace,
        string gameCode,
        string marketHashName,
        CancellationToken ct = default)
    {
        var url = ApiConnection.BuildUrl("/v2/items",
        [
            ("marketplace",     marketplace),
            ("game",            gameCode),
            ("name",            marketHashName),
        ]);
        return _connection.GetFlatAsync<MarketplaceItem>(url, ct);
    }
 
    /// <summary>
    /// Time-series price history for a single item on a single marketplace.
    /// </summary>
    /// <param name="marketplace">Marketplace name.</param>
    /// <param name="gameCode">Game code (e.g. <c>CS2</c>, <c>Dota2</c>, <c>Rust</c>, <c>TF2</c>).</param>
    /// <param name="marketHashName">Full item market name.</param>
    /// <param name="daysOfHistory">How many days of history to return. Defaults to <c>15</c>.</param>
    /// <param name="dataPoints">Maximum number of data points to return. The server downsamples evenly across the window. Defaults to 100.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>A time series of historical prices for a single item on a single marketplace. Useful for charts and trend analysis.</returns>
    public Task<ApiResult<MarketplacePriceHistory>> GetPriceHistoryAsync(
        string marketplace,
        string gameCode,
        string marketHashName,
        int? daysOfHistory = null,
        int? dataPoints = null,
        CancellationToken ct = default)
    {
        var url = ApiConnection.BuildUrl("/v2/price-history",
        [
            ("marketplace", marketplace),
            ("game",        gameCode),
            ("name",        marketHashName),
            ("days",        daysOfHistory?.ToString()),
            ("dataPoints",  dataPoints?.ToString()),
        ]);
        return _connection.GetFlatAsync<MarketplacePriceHistory>(url, ct);
    }
 
    /// <summary>
    /// Recent completed sales for a single item on a single marketplace, including per-sale metadata.
    /// </summary>
    /// <param name="marketplace">Marketplace name. Must be a marketplace that exposes sales — see https://docs.steamapis.com/market-data/rest/sales.</param>
    /// <param name="gameCode">Game code (e.g. <c>CS2</c>, <c>Dota2</c>, <c>Rust</c>, <c>TF2</c>).</param>
    /// <param name="marketHashName">Full item market name.</param>
    /// <param name="daysOfSales">How many days of sales history to return. Defaults to <c>30</c>.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Recent completed sales for a single item on a single marketplace, including per-sale metadata such as float, pattern, and stickers where available.</returns>
    public Task<ApiResult<MarketplaceSalesHistory>> GetSalesHistoryAsync(
        string marketplace,
        string gameCode,
        string marketHashName,
        int? daysOfSales = null,
        CancellationToken ct = default)
    {
        var url = ApiConnection.BuildUrl("/v2/sales",
        [
            ("marketplace",     marketplace),
            ("game",            gameCode),
            ("name",            marketHashName),
            ("days",            daysOfSales?.ToString()),
        ]);
        return _connection.GetFlatAsync<MarketplaceSalesHistory>(url, ct);
    }
    
    /// <summary>
    /// Compare the price and availability of a single item across multiple marketplaces in one request.
    /// </summary>
    /// <param name="gameCode">Game code (e.g. <c>CS2</c>, <c>Dota2</c>, <c>Rust</c>, <c>TF2</c>).</param>
    /// <param name="marketHashName">Full item market name.</param>
    /// <param name="marketplaces">Array of marketplace names to compare. Omit to compare across every supported marketplace.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The current state of a single item across multiple marketplaces in one request — useful for price arbitrage and cross-market lookups.</returns>
    public Task<ApiResult<ItemComparison>> CompareItemAsync(
        string gameCode,
        string marketHashName,
        IEnumerable<string> marketplaces,
        CancellationToken ct = default)
    {
        var url = ApiConnection.BuildUrl("/v2/items/compare",
        [
            ("game",        gameCode),
            ("name",        marketHashName),
            ("marketplaces",string.Join(",", marketplaces)),
        ]);
        return _connection.GetFlatAsync<ItemComparison>(url, ct);
    }
 
    /// <summary>
    /// List open buy orders from marketplaces that expose buy-order data.
    /// </summary>
    /// <param name="gameCode">Game code (e.g. <c>CS2</c>, <c>Dota2</c>, <c>Rust</c>, <c>TF2</c>).</param>
    /// <param name="marketplace">Optional marketplace filter. Must be a marketplace that exposes buy orders — see the table above.</param>
    /// <param name="marketHashName">Optional item name filter. Match is exact.</param>
    /// <param name="limit">Maximum number of orders to return. Defaults to <c>500</c>.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Open buy orders from marketplaces that expose buy-order data. Each order includes its item context (name, marketplace, game) so you can work with the response as a flat list.</returns>
    public Task<ApiResult<IReadOnlyList<MarketplaceBuyOrdersEntry>>> GetBuyOrdersAsync(
        string gameCode,
        string? marketplace = null,
        string? marketHashName = null,
        int? limit = null,
        CancellationToken ct = default)
    {
        var url = ApiConnection.BuildUrl("/v2/buy-orders",
        [
            ("game",            gameCode),
            ("marketplace",     marketplace),
            ("name",            marketHashName),
            ("limit",            limit?.ToString()),
        ]);
        return _connection.GetFlatAsync<IReadOnlyList<MarketplaceBuyOrdersEntry>>(url, ct);
    }
}