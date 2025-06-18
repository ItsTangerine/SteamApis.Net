using System.Text.Json;
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
            Converters = { new JsonEnumMemberStringEnumConverter() },
        };
    }
    
    /// <inheritdoc cref="ISteamApisClient.GetUserSteamInventory"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<InventoryResponse> GetUserSteamInventory(string steamId, int appId, int contextId, bool legacy = false, CancellationToken cancellationToken = default)
    {
        EnsureApiKeyProvided();
        
        var url = $"steam/inventory/{steamId}/{appId}/{contextId}?api_key={_options.ApiKey}";

        if (legacy)
        {
            url += "&legacy=1";
        }

        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<InventoryResponse>(stream, _jsonOptions, cancellationToken);

        return result ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    /// <inheritdoc cref="ISteamApisClient.GetUserSteamProfile"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<SteamProfileResponse> GetUserSteamProfile(string steamId, CancellationToken cancellationToken = default)
    {
        EnsureApiKeyProvided();
        
        // Construct the endpoint URL
        var url = $"steam/profile/{steamId}?api_key={_options.ApiKey}";
        
        // Send HTTP GET request
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        // Deserialize response JSON into your model
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<SteamProfileResponse>(stream, _jsonOptions, cancellationToken);

        return result ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    /// <inheritdoc cref="ISteamApisClient.GetMarketStats"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<GlobalStatsResponse> GetMarketStats(CancellationToken cancellationToken = default)
    {
        EnsureApiKeyProvided();
        
        // Construct the endpoint URL
        var url = $"market/stats?api_key={_options.ApiKey}";
        
        // Send HTTP GET request
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        // Deserialize response JSON into your model
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<GlobalStatsResponse>(stream, _jsonOptions, cancellationToken);

        return result ?? throw new InvalidOperationException("Failed to deserialize inventory response.");
    }

    /// <inheritdoc cref="ISteamApisClient.GetSingleApp"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<SteamAppDetailsResponse> GetSingleApp(int appId, CancellationToken cancellationToken = default)
    {
        EnsureApiKeyProvided();
        
        // Construct the endpoint URL
        var url = $"market/app/{appId}?api_key={_options.ApiKey}";
        
        // Send HTTP GET request
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        // Deserialize response JSON into your model
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<SteamAppDetailsResponse>(stream, _jsonOptions, cancellationToken);

        return result ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllApps"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<SteamAppDetailsShortResponse[]> GetAllApps(CancellationToken cancellationToken = default)
    {
        EnsureApiKeyProvided();
        
        // Construct the endpoint URL
        var url = $"market/apps?api_key={_options.ApiKey}";
        
        // Send HTTP GET request
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        // Deserialize response JSON into your model
        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<SteamAppDetailsShortResponse[]>(stream, _jsonOptions, cancellationToken);

        return result ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    /// <inheritdoc cref="ISteamApisClient.GetSingleItem"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<SteamMarketItemResponse> GetSingleItem(int appId, string marketHashName, int medianHistoryDays = 15, CancellationToken cancellationToken = default)
    {
        EnsureApiKeyProvided();
        
        var url = $"market/item/{appId}/{marketHashName}?api_key={_options.ApiKey}";

        if (medianHistoryDays != 15)
        {
            url += $"&median_history_days={medianHistoryDays}";
        }
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<SteamMarketItemResponse>(stream, _jsonOptions, cancellationToken);

        return result ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllItems"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<AppItemsResponse> GetAllItems(int appId, CancellationToken cancellationToken = default)
    {
        EnsureApiKeyProvided();
        
        var url = $"market/items/{appId}?api_key={_options.ApiKey}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<AppItemsResponse>(stream, _jsonOptions, cancellationToken);

        return result ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllItemsCompact"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<Dictionary<string, double>> GetAllItemsCompact(int appId, CompactValue compactValue = CompactValue.Safe, CancellationToken cancellationToken = default)
    {
        EnsureApiKeyProvided();
        
        var url = $"market/items/{appId}?api_key={_options.ApiKey}&format=compact";

        if (compactValue != CompactValue.Safe)
        {
            url += $"&compact={compactValue.GetEnumMemberValue()}";
        }
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<Dictionary<string, double>>(stream, _jsonOptions, cancellationToken);

        return result ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    /// <inheritdoc cref="ISteamApisClient.GetAllCards"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<SteamCardSetResponse> GetAllCards(CancellationToken cancellationToken = default)
    {
        EnsureApiKeyProvided();
        
        var url = $"market/items/cards?api_key={_options.ApiKey}&format=compact";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<SteamCardSetResponse>(stream, _jsonOptions, cancellationToken);

        return result ?? throw new InvalidOperationException("Failed to deserialize response.");
    }

    /// <inheritdoc cref="ISteamApisClient.GetImage"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<byte[]> GetImage(int appId, string marketHashName, CancellationToken cancellationToken = default)
    {
        var url = $"image/item/{appId}/{marketHashName}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsByteArrayAsync(cancellationToken);
    }

    /// <inheritdoc cref="ISteamApisClient.GetImages"/>
    /// <exception cref="HttpRequestException">The HTTP response is unsuccessful.</exception>
    /// <exception cref="InvalidOperationException">Failed to deserialize response.</exception>
    public async ValueTask<Dictionary<string, string>> GetImages(int appId, CancellationToken cancellationToken = default)
    {
        var url = $"image/items/{appId}";
        
        var response = await _httpClient.GetAsync(url, cancellationToken);

        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
        var result = await JsonSerializer.DeserializeAsync<Dictionary<string, string>>(stream, _jsonOptions, cancellationToken);

        return result ?? throw new InvalidOperationException("Failed to deserialize response.");
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

    /// <summary>
    /// Throws an exception of API key is not provided
    /// </summary>
    /// <exception cref="ArgumentException">API key is not provided.</exception>
    private void EnsureApiKeyProvided()
    {
        if (string.IsNullOrWhiteSpace(_options.ApiKey) == false)
            return;
        
        throw new ArgumentException("API Key is not provided, please check your options.");
    }
}