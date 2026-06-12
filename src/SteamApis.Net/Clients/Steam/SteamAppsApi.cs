using SteamApis.Net.Http;
using SteamApis.Net.Models.App;
using SteamApis.Net.Models.Common;
using SteamApis.Net.Models.Response;
using SteamApis.Net.Models.SteamApis;

namespace SteamApis.Net.Clients.Steam;

/// <summary>
/// Client for SteamApis Steam API v2 endpoint groups.
/// </summary>
public sealed class SteamAppsApi
{
    private readonly ApiConnection _connection;

    internal SteamAppsApi(ApiConnection connection) => _connection = connection;

    /// <summary>
    /// Get a paginated list of all Steam applications tracked by SteamApis.
    /// </summary>
    /// <param name="cursor">Pagination cursor. Pass the cursor value from a previous response to fetch the next page of results.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Paginated list of all Steam applications (games, DLC, software, etc.) tracked by SteamApis. Use the <paramref name="cursor"/> parameter to paginate through results.</returns>
    public Task<ApiResult<PagedApiResponse<SteamApp>>> ListAsync(string? cursor = null, CancellationToken ct = default)
        => _connection.GetPagedAsync<SteamApp>(ApiConnection.BuildUrl("/v2/steam/apps", [("cursor", cursor)]), ct);

    /// <summary>
    /// Get current concurrent player counts for all Steam applications tracked by SteamApis, paginated.
    /// </summary>
    /// <param name="cursor">Pagination cursor. Pass the cursor value from a previous response to fetch the next page of results.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Paginated list of Steam applications along with their most recent concurrent player count. Use the <paramref name="cursor"/> parameter to paginate through results.</returns>
    public Task<ApiResult<PagedApiResponse<GamePlayerCounts>>> GetPlayerCountsAsync(string? cursor = null, CancellationToken ct = default)
        => _connection.GetPagedAsync<GamePlayerCounts>(ApiConnection.BuildUrl("/v2/steam/apps/player-counts", [("cursor", cursor)]), ct);

    /// <summary>
    /// Get detailed information about a specific Steam application including descriptions, images, pricing, and metadata.
    /// </summary>
    /// <param name="appId">The Steam application ID.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Detailed information about a specific Steam application, including descriptions, images, pricing, system requirements, and other metadata.</returns>
    public Task<ApiResult<AppDetails>> GetDetailsAsync(int appId, CancellationToken ct = default)
        => _connection.GetResultAsync<AppDetails>($"/v2/steam/apps/{appId}", ct);

    /// <summary>
    /// Get a paginated changelog of tracked changes for a specific Steam application.
    /// </summary>
    /// <param name="appId">The Steam application ID.</param>
    /// <param name="cursor">Pagination cursor. Pass the cursor value from a previous response to fetch the next page.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Paginated list of tracked changes for a specific Steam application. Changes are recorded when app data (name, price, details, etc.) is modified.</returns>
    public Task<ApiResult<PagedApiResponse<ChangeLogEntry>>> GetChangesAsync(int appId, string? cursor = null, CancellationToken ct = default)
        => _connection.GetPagedAsync<ChangeLogEntry>(ApiConnection.BuildUrl($"/v2/steam/apps/{appId}/changes", [("cursor", cursor)]), ct);

    /// <summary>
    /// Get the global unlock percentage for each achievement in a Steam game.
    /// </summary>
    /// <param name="appId">The Steam application ID of the game whose global achievement percentages you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The global achievement completion rate for a specific Steam game — that is, the percentage of players who have unlocked each achievement across the entire Steam player base. Results are ordered from most-unlocked to least-unlocked.</returns>
    public Task<ApiResult<IReadOnlyList<GlobalAchievementEntry>>> GetGlobalAchievementsAsync(int appId, CancellationToken ct = default)
        => _connection.GetResultAsync<IReadOnlyList<GlobalAchievementEntry>>($"/v2/steam/apps/{appId}/global-achievements", ct);
    
    /// <summary>
    /// Get the latest news items for a Steam game, including community announcements and external press coverage.
    /// </summary>
    /// <param name="appId">The Steam application ID of the game whose news you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The latest news items for a specific Steam game, aggregating Steam Community Announcements and external press feeds (PC Gamer, PCGamesN, SteamDB, Rock Paper Shotgun, and so on). Items are ordered newest-first by publishedTimestamp.</returns>
    public Task<ApiResult<IReadOnlyList<AppNews>>> GetNewsAsync(int appId, CancellationToken ct = default)
        => _connection.GetResultAsync<IReadOnlyList<AppNews>>($"/v2/steam/apps/{appId}/news", ct);

    /// <summary>
    /// Get the full stats and achievements schema for a Steam game, including display names, descriptions, and icon URLs.
    /// </summary>
    /// <param name="appId">The Steam application ID of the game whose schema you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The complete schema for a Steam game's tracked stats and achievements, as published by the game's developer on Steam. Use it to resolve a stat's or achievement's internal identifier (as returned by the stats endpoint and the achievements endpoint) to a localized display name, description, and icon.</returns>
    public Task<ApiResult<SteamGameSchema>> GetSchemaAsync(int appId, CancellationToken ct = default)
        => _connection.GetResultAsync<SteamGameSchema>($"/v2/steam/apps/{appId}/schema", ct);
    
    /// <summary>
    /// Get a ranked list of Steam apps for a given store ranking category (for example, top sellers or popular new releases).
    /// </summary>
    /// <param name="type">The ranking category to fetch. Known values:</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Ranked list of Steam apps for a given Steam Store ranking category, such as popular new releases. Entries are ordered by their current rank.</returns>
    /// <remarks>
    /// Supported type values:
    /// <list type="bullet">
    /// <item><description><c>popularnew</c> – Popular New Releases.</description></item>
    /// <item><description><c>topsellers</c> – Top Sellers.</description></item>
    /// <item><description><c>popularcomingsoon</c> – Popular Upcoming Releases.</description></item>
    /// <item><description><c>specials</c> – Apps currently on sale.</description></item>
    /// <item><description><c>trendingfree</c> – Popular free-to-play apps.</description></item>
    /// <item><description><c>mostplayed</c> – Top 50 apps by current player count from Steam's Most Played chart.</description></item>
    /// </list>
    /// </remarks>
    public Task<ApiResult<StoreRanking>> GetStoreRankingsAsync(
        string type = "popularnew", CancellationToken ct = default)
        => _connection.GetResultAsync<StoreRanking>($"/v2/steam/apps/store/rankings/{type}", ct);
    
    /// <summary>
    /// Get a paginated list of user reviews for a specific Steam application.
    /// </summary>
    /// <param name="appId">The Steam application ID.</param>
    /// <param name="cursor">Pagination cursor. Pass the cursor value from a previous response to fetch the next page.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Paginated list of user reviews for a specific Steam application. Each entry includes the review text, the author's Steam ID and playtime at review time, vote counts, and timestamps.</returns>
    public Task<ApiResult<PagedApiResponse<SteamReview>>> GetReviewsAsync(int appId, string? cursor = null, CancellationToken ct = default)
        => _connection.GetPagedAsync<SteamReview>(ApiConnection.BuildUrl($"/v2/steam/apps/{appId}/reviews", [("cursor", cursor)]), ct);
}