using SteamApis.Net.Http;
using SteamApis.Net.Models.Response;
using SteamApis.Net.Models.Steam;

namespace SteamApis.Net.Clients.Steam;

public sealed class SteamUsersApi
{
    private readonly ApiConnection _connection;

    internal SteamUsersApi(ApiConnection connection) => _connection = connection;

    /// <summary>
    /// Get Steam user profile data including display name, avatar, online status, and account details.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user whose profile you want to fetch. Accepts various Steam ID formats.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Detailed profile information for a Steam user via the official Steam API. It provides summary data including the user's display name, avatar, online status, and account metadata.</returns>
    public Task<ApiResult<SteamUser>> GetAsync(string steamId, CancellationToken ct = default)
        => _connection.GetResultAsync<SteamUser>($"/v2/steam/users/{Uri.EscapeDataString(steamId)}", ct);

    /// <summary>
    /// Get the Steam groups a user belongs to, as a list of group IDs.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user whose groups you want to fetch. Accepts various Steam ID formats.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The list of Steam groups a user is a member of. The response is an array of group IDs as strings.</returns>
    public Task<ApiResult<IReadOnlyList<string>>> GetGroupsAsync(string steamId, CancellationToken ct = default)
        => _connection.GetResultAsync<IReadOnlyList<string>>($"/v2/steam/users/{Uri.EscapeDataString(steamId)}/groups", ct);

    /// <summary>
    /// Fetch a Steam user's inventory for a given app and context, returning assets alongside the descriptions that resolve each asset's visual and market metadata.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user whose inventory you want to fetch. Accepts various Steam ID formats.</param>
    /// <param name="appId">The Steam application ID of the game whose inventory you want to fetch (e.g. 730 for Counter-Strike 2).</param>
    /// <param name="contextId">The context ID within the app's inventory. For most games the context ID is 2.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>User's Steam inventory for a specific app and context. The response mirrors Steam's own inventory shape: an assets array listing the items owned and a descriptions array that resolves each asset's visual and market metadata by classid + instanceid.</returns>
    public Task<ApiResult<Inventory>> GetInventoryAsync(string steamId, int appId, int contextId = 2, CancellationToken ct = default)
        => _connection.GetFlatAsync<Inventory>($"/v2/steam/users/{Uri.EscapeDataString(steamId)}/inventory/{appId}/{contextId}", ct);

    /// <summary>
    /// Get Steam user badges including XP, level, and completion details.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user whose badges you want to fetch. Accepts various Steam ID formats.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The badge data for a Steam user, including badge level, XP earned, and completion timestamps. This data was previously part of the v1 summary endpoint and is now available as a dedicated endpoint.</returns>
    public Task<ApiResult<UserBadges>> GetBadgesAsync(string steamId, CancellationToken ct = default)
        => _connection.GetResultAsync<UserBadges>($"/v2/steam/users/{Uri.EscapeDataString(steamId)}/badges", ct);

    /// <summary>
    /// Get a list of games owned by a Steam user including playtime statistics and extended app info.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user whose game library you want to fetch. Accepts various Steam ID formats.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>List of games owned by the specified user, including playtime statistics and extended application information. The user's game library must be set to public for this endpoint to return data.</returns>
    public Task<ApiResult<IReadOnlyList<UserGame>>> GetGamesAsync(string steamId, CancellationToken ct = default)
        => _connection.GetResultAsync<IReadOnlyList<UserGame>>($"/v2/steam/users/{Uri.EscapeDataString(steamId)}/games", ct);
    
    /// <summary>
    /// Get Steam user ban status including VAC bans, game bans, and trade ban information.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user whose ban status you want to check. Accepts various Steam ID formats.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The ban status for a Steam user, including VAC bans, game bans, community ban status, and trade ban information.</returns>
    public Task<ApiResult<UserBans>> GetBansAsync(string steamId, CancellationToken ct = default)
        => _connection.GetResultAsync<UserBans>($"/v2/steam/users/{Uri.EscapeDataString(steamId)}/bans", ct);

    /// <summary>
    /// Resolve Steam vanity URLs to Steam IDs. Convert custom profile URLs to numeric identifiers.
    /// </summary>
    /// <param name="vanityUrl">The vanity URL name to resolve (e.g. pepzwee from steamcommunity.com/id/pepzwee).</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>Resolves a Steam vanity URL name to a Steam ID. Vanity URLs are custom profile URLs that users can set (e.g. steamcommunity.com/id/pepzwee).</returns>
    public Task<ApiResult<UserVanity>> ResolveVanityAsync(string vanityUrl, CancellationToken ct = default)
        => _connection.GetResultAsync<UserVanity>($"/v2/steam/users/vanity/{Uri.EscapeDataString(vanityUrl)}", ct);
    
    /// <summary>
    /// Get the games a Steam user has played recently, including total and recent playtime broken down by platform.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user whose recent activity you want to fetch. Accepts various Steam ID formats.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The list of games a Steam user has played in the last two weeks, along with total playtime and per-platform playtime breakdowns.</returns>
    public Task<ApiResult<IReadOnlyList<RecentGame>>> GetRecentlyPlayedAsync(string steamId, CancellationToken ct = default)
        => _connection.GetResultAsync<IReadOnlyList<RecentGame>>($"/v2/steam/users/{Uri.EscapeDataString(steamId)}/recently-played", ct);
    
    /// <summary>
    /// Get a Steam user's achievements for a specific game, including unlock state and timestamp.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user whose achievements you want to fetch. Accepts various Steam ID formats.</param>
    /// <param name="appId">The Steam application ID of the game whose achievements you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The list of achievements for a specific game on a Steam user's account, with the current unlock state and unlock timestamp for each achievement.</returns>
    public Task<ApiResult<SteamGameAchievements>> GetGameAchievementsAsync(string steamId, int appId, CancellationToken ct = default)
        => _connection.GetResultAsync<SteamGameAchievements>($"/v2/steam/users/{Uri.EscapeDataString(steamId)}/achievements/{appId}", ct);

    /// <summary>
    /// Get a Steam user's in-game stats and achievements for a specific game.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user whose stats you want to fetch. Accepts various Steam ID formats.</param>
    /// <param name="appId">The Steam application ID of the game whose stats you want to fetch.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The in-game stats and unlocked achievements for a specific game on a Steam user's account. The available stat names are defined by each game's stats schema and vary per title.</returns>
    public Task<ApiResult<SteamGameStats>> GetGameStatsAsync(string steamId, int appId, CancellationToken ct = default)
        => _connection.GetResultAsync<SteamGameStats>($"/v2/steam/users/{Uri.EscapeDataString(steamId)}/stats/{appId}", ct);
    
    /// <summary>
    /// Get a Steam user's friends list, including each friend's SteamID, when they were friended, and the relationship type.
    /// </summary>
    /// <param name="steamId">The Steam ID of the user whose friends list you want to fetch. Accepts various Steam ID formats.</param>
    /// <param name="ct">Cancellation token for the request.</param>
    /// <returns>The friends list for a Steam user. The user's friends list must be set to public for this endpoint to return data.</returns>
    public Task<ApiResult<IReadOnlyList<Friend>>> GetFriendsAsync(string steamId, CancellationToken ct = default)
        => _connection.GetResultAsync<IReadOnlyList<Friend>>($"/v2/steam/users/{Uri.EscapeDataString(steamId)}/friends", ct);
    

}