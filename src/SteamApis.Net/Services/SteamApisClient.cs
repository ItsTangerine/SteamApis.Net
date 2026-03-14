using System.Text.Json;
using System.Text.Json.Serialization;
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
using SteamApis.Net.Extensions;
using SteamApis.Net.Json;
using SteamApis.Net.Services.Config;

namespace SteamApis.Net.Services;

public class SteamApisClient : ISteamApisClient
{
    private readonly HttpClient _httpClient;
    private readonly SteamApisOptions _options;
    private readonly JsonSerializerOptions _jsonOptions;

    public SteamApisClient(HttpClient httpClient, SteamApisOptions options)
    {
        _httpClient = httpClient;
        _options = options;
        _jsonOptions = new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true,
            Converters = { new EnumMemberConverterFactory() },
        };
    }
    
    /// <inheritdoc cref="ISteamApisClient.GetUserSteamInventory"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<InventoryResponse>> GetUserSteamInventory(string steamId, int appId, int contextId, bool legacy = false, CancellationToken cancellationToken = default)
    {
        var url = $"steam/inventory/{steamId}/{appId}/{contextId}?api_key={_options.ApiKey}";

        if (legacy)
        {
            url += "&legacy=1";
        }

        return GetAsync<InventoryResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetUserSteamProfile"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<SteamProfileResponse>> GetUserSteamProfile(string steamId, CancellationToken cancellationToken = default)
    {
        var url = $"steam/profile/{steamId}?api_key={_options.ApiKey}";
        
        return GetAsync<SteamProfileResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetUserSteamVanity"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<SteamVanityResponse>> GetUserSteamVanity(string vanityName, CancellationToken cancellationToken = default)
    {
        var url = $"steam/profile/vanity/{vanityName}?api_key={_options.ApiKey}";
        
        return GetAsync<SteamVanityResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetUserSteamSummary"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<SteamSummaryResponse>> GetUserSteamSummary(string steamId, CancellationToken cancellationToken = default)
    {
        var url = $"steam/profile/{steamId}/summary?api_key={_options.ApiKey}";
        
        return GetAsync<SteamSummaryResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetUserSteamGames"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<SteamGamesResponse>> GetUserSteamGames(string steamId, CancellationToken cancellationToken = default)
    {
        var url = $"steam/profile/{steamId}/games?api_key={_options.ApiKey}";
        
        return GetAsync<SteamGamesResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetMarketStats"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<GlobalStatsResponse>> GetMarketStats(CancellationToken cancellationToken = default)
    {
        var url = $"market/stats?api_key={_options.ApiKey}";
        
        return GetAsync<GlobalStatsResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetSingleApp"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<SteamAppDetailsResponse>> GetSingleApp(int appId, CancellationToken cancellationToken = default)
    {
        var url = $"market/app/{appId}?api_key={_options.ApiKey}";
        
        return GetAsync<SteamAppDetailsResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllApps"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<SteamAppDetailsShortResponse[]>> GetAllApps(CancellationToken cancellationToken = default)
    {
        var url = $"market/apps?api_key={_options.ApiKey}";
        
        return GetAsync<SteamAppDetailsShortResponse[]>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetSingleItem"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<SteamMarketItemResponse>> GetSingleItem(int appId, string marketHashName, int medianHistoryDays = 15, CancellationToken cancellationToken = default)
    {
        var url = $"market/item/{appId}/{marketHashName}?api_key={_options.ApiKey}";

        if (medianHistoryDays != 15)
        {
            url += $"&median_history_days={medianHistoryDays}";
        }
        
        return GetAsync<SteamMarketItemResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllItems"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<AppItemsResponse>> GetAllItems(int appId, CancellationToken cancellationToken = default)
    {
        var url = $"market/items/{appId}?api_key={_options.ApiKey}";
        
        return GetAsync<AppItemsResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllItemsCompact"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<Dictionary<string, double>>> GetAllItemsCompact(int appId, CompactValue compactValue = CompactValue.Safe, CancellationToken cancellationToken = default)
    {
        var url = $"market/items/{appId}?api_key={_options.ApiKey}&format=compact";

        if (compactValue != CompactValue.Safe)
        {
            url += $"&compact={compactValue.GetEnumMemberValue()}";
        }
        
        return GetAsync<Dictionary<string, double>>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllCards"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<SteamCardSetResponse>> GetAllCards(CancellationToken cancellationToken = default)
    {
        var url = $"market/items/cards?api_key={_options.ApiKey}&format=compact";
        
        return GetAsync<SteamCardSetResponse>(url, cancellationToken);
    }

    public Task<ApiResult<MarketDescriptionsResponse>> GetMarketDescriptions(int appId, int page = 1, CancellationToken cancellationToken = default)
    {
        var url = $"market/items/{appId}/descriptions?api_key={_options.ApiKey}";
        
        if(page > 1)
            url += $"&page={page}";
        
        return GetAsync<MarketDescriptionsResponse>(url, cancellationToken);
    }

    public Task<ApiResult<MarketHistogramData[]>> GetMarketHistograms(int appId, CancellationToken cancellationToken = default)
    {
        var url = $"market/items/{appId}/histograms?api_key={_options.ApiKey}";
        
        return GetAsync<MarketHistogramData[]>(url, cancellationToken);
    }

    public Task<ApiResult<MarketAssetInfosResponse>> GetMarketAssetInfos(int appId, string? cursor = null, CancellationToken cancellationToken = default)
    {
        var url = $"market/items/{appId}/assetinfos?api_key={_options.ApiKey}";
        
        if(string.IsNullOrEmpty(cursor) == false)
            url += $"&cursor={cursor}";
        
        return GetAsync<MarketAssetInfosResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetImage"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async Task<ApiResult<byte[]>> GetImage(int appId, string marketHashName, CancellationToken cancellationToken = default)
    {
        var url = $"image/item/{appId}/{marketHashName}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        
        if (!response.IsSuccessStatusCode)
        {
            var error = await ParseErrorResponse(stream, cancellationToken);
            return ApiResult<byte[]>.Failure(
                error?.Error ?? $"HTTP {(int)response.StatusCode}",
                response.StatusCode);
        }

        var imageBytes = await response.Content.ReadAsByteArrayAsync(cancellationToken);
        return ApiResult<byte[]>.Success(imageBytes, response.StatusCode);
    }

    /// <inheritdoc cref="ISteamApisClient.GetImages"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public Task<ApiResult<Dictionary<string, string>>> GetImages(int appId, CancellationToken cancellationToken = default)
    {
        var url = $"image/items/{appId}";
        
        return GetAsync<Dictionary<string, string>>(url, cancellationToken);
    }
    
    public static ISteamApisClient Create(SteamApisOptions options)
    {
        var httpClient = new HttpClient
        {
            BaseAddress = new Uri(options.BaseUrl),
            Timeout = options.Timeout
        };
        
        return new SteamApisClient(httpClient, options);
    }

    private async Task<ApiResult<T>> GetAsync<T>(string url, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(url, cancellationToken);
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var error = await ParseErrorResponse(stream, cancellationToken);
            return ApiResult<T>.Failure(
                error?.Error ?? $"HTTP {(int)response.StatusCode}",
                response.StatusCode);
        }

        var result = await DeserializeResponse<T>(stream, cancellationToken);

        if (result is null)
        {
            return ApiResult<T>.Failure(
                "Failed to deserialize response.",
                response.StatusCode);
        }

        return ApiResult<T>.Success(result, response.StatusCode);
    }
    
    private async Task<ErrorResponse?> ParseErrorResponse(Stream stream, CancellationToken cancellationToken)
    {
        try
        {
            return await DeserializeResponse<ErrorResponse>(stream, cancellationToken);
        }
        catch (JsonException e)
        {
            return new ErrorResponse(e.Message);
        }
    }

    private async Task<T?> DeserializeResponse<T>(Stream stream, CancellationToken cancellationToken)
    {
        return await JsonSerializer.DeserializeAsync<T>(stream, _jsonOptions, cancellationToken);
    }

}