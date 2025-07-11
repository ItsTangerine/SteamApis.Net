using System.Text.Json;
using System.Text.Json.Serialization;
using SteamApis.Net.Entities.Response;
using SteamApis.Net.Entities.Response.Market.App;
using SteamApis.Net.Entities.Response.Market.Apps;
using SteamApis.Net.Entities.Response.Market.Cards;
using SteamApis.Net.Entities.Response.Market.Item;
using SteamApis.Net.Entities.Response.Market.Items;
using SteamApis.Net.Entities.Response.Market.Stats;
using SteamApis.Net.Entities.Response.Steam.Inventory;
using SteamApis.Net.Entities.Response.Steam.Profile;
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
    public async ValueTask<InventoryResponse> GetUserSteamInventory(string steamId, int appId, int contextId, bool legacy = false, CancellationToken cancellationToken = default)
    {
        var url = $"steam/inventory/{steamId}/{appId}/{contextId}?api_key={_options.ApiKey}";

        if (legacy)
        {
            url += "&legacy=1";
        }

        return await GetAsync<InventoryResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetUserSteamProfile"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<SteamProfileResponse> GetUserSteamProfile(string steamId, CancellationToken cancellationToken = default)
    {
        var url = $"steam/profile/{steamId}?api_key={_options.ApiKey}";
        
        return await GetAsync<SteamProfileResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetMarketStats"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<GlobalStatsResponse> GetMarketStats(CancellationToken cancellationToken = default)
    {
        var url = $"market/stats?api_key={_options.ApiKey}";
        
        return await GetAsync<GlobalStatsResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetSingleApp"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<SteamAppDetailsResponse> GetSingleApp(int appId, CancellationToken cancellationToken = default)
    {
        var url = $"market/app/{appId}?api_key={_options.ApiKey}";
        
        return await GetAsync<SteamAppDetailsResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllApps"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<SteamAppDetailsShortResponse[]> GetAllApps(CancellationToken cancellationToken = default)
    {
        var url = $"market/apps?api_key={_options.ApiKey}";
        
        return await GetAsync<SteamAppDetailsShortResponse[]>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetSingleItem"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<SteamMarketItemResponse> GetSingleItem(int appId, string marketHashName, int medianHistoryDays = 15, CancellationToken cancellationToken = default)
    {
        var url = $"market/item/{appId}/{marketHashName}?api_key={_options.ApiKey}";

        if (medianHistoryDays != 15)
        {
            url += $"&median_history_days={medianHistoryDays}";
        }
        
        return await GetAsync<SteamMarketItemResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllItems"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<AppItemsResponse> GetAllItems(int appId, CancellationToken cancellationToken = default)
    {
        var url = $"market/items/{appId}?api_key={_options.ApiKey}";
        
        return await GetAsync<AppItemsResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllItemsCompact"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<Dictionary<string, double>> GetAllItemsCompact(int appId, CompactValue compactValue = CompactValue.Safe, CancellationToken cancellationToken = default)
    {
        var url = $"market/items/{appId}?api_key={_options.ApiKey}&format=compact";

        if (compactValue != CompactValue.Safe)
        {
            url += $"&compact={compactValue.GetEnumMemberValue()}";
        }
        
        return await GetAsync<Dictionary<string, double>>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllCards"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<SteamCardSetResponse> GetAllCards(CancellationToken cancellationToken = default)
    {
        var url = $"market/items/cards?api_key={_options.ApiKey}&format=compact";
        
        return await GetAsync<SteamCardSetResponse>(url, cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetImage"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<byte[]> GetImage(int appId, string marketHashName, CancellationToken cancellationToken = default)
    {
        var url = $"image/item/{appId}/{marketHashName}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        
        await HandleErrorResponse(response, stream, cancellationToken);

        return await response.Content.ReadAsByteArrayAsync(cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetImages"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<Dictionary<string, string>> GetImages(int appId, CancellationToken cancellationToken = default)
    {
        var url = $"image/items/{appId}";
        
        return await GetAsync<Dictionary<string, string>>(url, cancellationToken);
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

    private async ValueTask<T> GetAsync<T>(string url, CancellationToken cancellationToken)
    {
        var response = await _httpClient.GetAsync(url, cancellationToken);
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        
        await HandleErrorResponse(response, stream, cancellationToken);
        var result = await DeserializeResponse<T>(stream, cancellationToken);
        
        return result ?? throw new InvalidOperationException("Failed to deserialize response.");
    }
    
    private async Task HandleErrorResponse(HttpResponseMessage response, Stream stream, CancellationToken cancellationToken)
    {
        if (response.IsSuccessStatusCode)
            return;
        
        var errorResult = await DeserializeResponse<ErrorResponse>(stream, cancellationToken);
        if (string.IsNullOrEmpty(errorResult?.Error) == false)
        {
            throw new HttpRequestException(errorResult.Error);
        }
    
        response.EnsureSuccessStatusCode();
    }

    private async Task<T?> DeserializeResponse<T>(Stream stream, CancellationToken cancellationToken)
    {
        stream.Position = 0; // Reset stream position for reading
        return await JsonSerializer.DeserializeAsync<T>(stream, _jsonOptions, cancellationToken);
    }

}