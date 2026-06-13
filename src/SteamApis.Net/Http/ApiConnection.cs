using System.Net;
using System.Net.Http.Json;
using System.Text.Json;
using SteamApis.Net.Json;
using SteamApis.Net.Models.Response;
using SteamApis.Net.Models.SteamApis;

namespace SteamApis.Net.Http;

/// <summary>
/// Single transport used by all API sections. Owns the HttpClient,
/// JSON options, error mapping and URL building.
/// </summary>
public sealed class ApiConnection(HttpClient httpClient)
{
    private static readonly JsonSerializerOptions JsonOptions = new()
    {
        PropertyNameCaseInsensitive = true,
        Converters = { new EnumMemberConverterFactory() },
    };

    public async Task<ApiResult<T>> GetResultAsync<T>(string url, CancellationToken ct = default) where T : class
    {
        try
        {
            using var response = await httpClient.GetAsync(url, ct);
            if (!response.IsSuccessStatusCode)
                return await ReadSteamErrorAsync<T>(response, ct);
 
            var envelope = await response.Content.ReadFromJsonAsync<ApiResponse<T>>(JsonOptions, ct);
            if (envelope?.Result is null)
                return ApiResult<T>.Fail(200, "EmptyResult", $"No result payload at {url}");
 
            return ApiResult<T>.Ok(envelope.Result);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            return ApiResult<T>.Fail(0, "NetworkError", ex.Message);
        }
    }
 
    public async Task<ApiResult<PagedApiResponse<T>>> GetPagedAsync<T>(string url, CancellationToken ct = default)
    {
        try
        {
            using var response = await httpClient.GetAsync(url, ct);
            if (!response.IsSuccessStatusCode)
                return await ReadSteamErrorAsync<PagedApiResponse<T>>(response, ct);
 
            var paged = await response.Content.ReadFromJsonAsync<PagedApiResponse<T>>(JsonOptions, ct);
            if (paged is null)
                return ApiResult<PagedApiResponse<T>>.Fail(200, "EmptyResult", $"No payload at {url}");
 
            return ApiResult<PagedApiResponse<T>>.Ok(paged);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            return ApiResult<PagedApiResponse<T>>.Fail(0, "NetworkError", ex.Message);
        }
    }
 
    public async Task<ApiResult<T>> GetFlatAsync<T>(string url, CancellationToken ct = default)
    {
        try
        {
            using var response = await httpClient.GetAsync(url, ct);
            if (!response.IsSuccessStatusCode)
                return await ReadMarketErrorAsync<T>(response, ct);
 
            var value = await response.Content.ReadFromJsonAsync<T>(JsonOptions, ct);
            if (value is null)
                return ApiResult<T>.Fail(200, "EmptyResult", $"No payload at {url}");
 
            return ApiResult<T>.Ok(value);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            return ApiResult<T>.Fail(0, "NetworkError", ex.Message);
        }
    }
    
    public async Task<ApiResult<byte[]>> GetBytesAsync(string url, CancellationToken ct = default)
    {
        try
        {
            using var response = await httpClient.GetAsync(url, ct);
            if (!response.IsSuccessStatusCode)
                return await ReadMarketErrorAsync<byte[]>(response, ct);
 
            var value = await response.Content.ReadAsByteArrayAsync(ct);
            if (value.Length == 0)
                return ApiResult<byte[]>.Fail(200, "EmptyResult", $"No payload at {url}");
 
            return ApiResult<byte[]>.Ok(value);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            return ApiResult<byte[]>.Fail(0, "NetworkError", ex.Message);
        }
    }
 
    private static async Task<ApiResult<T>> ReadSteamErrorAsync<T>(HttpResponseMessage response, CancellationToken ct)
    {
        SteamApiError? apiError = null;
        try
        {
            var envelope = await response.Content
                .ReadFromJsonAsync<ApiResponse<object>>(cancellationToken: ct);
            if (envelope?.Error is { } e)
                apiError = new SteamApiError { Name = e.Name, Message = e.Message };
        }
        catch { /* best-effort */ }
 
        var status = (int)response.StatusCode;
        var code   = MapStatusToCode(response.StatusCode, apiError?.Message);
        var msg    = apiError?.Message ?? response.ReasonPhrase;
        return ApiResult<T>.Fail(status, code, msg);
    }
 
    private static async Task<ApiResult<T>> ReadMarketErrorAsync<T>(HttpResponseMessage response, CancellationToken ct)
    {
        MarketplaceApiError? marketError = null;
        try
        {
            marketError = await response.Content
                .ReadFromJsonAsync<MarketplaceApiError>(cancellationToken: ct);
        }
        catch { /* best-effort */ }
 
        var status = (int)response.StatusCode;
        var code   = marketError?.Code ?? MapStatusToCode(response.StatusCode, null);
        var msg    = marketError?.Error ?? response.ReasonPhrase;
        return ApiResult<T>.Fail(status, code, msg);
    }
 
    private static string MapStatusToCode(HttpStatusCode status, string? serverMessage) =>
        serverMessage switch
        {
            "MISSING_API_KEY"      => "MISSING_API_KEY",
            "INVALID_API_KEY"      => "INVALID_API_KEY",
            "ACCESS_DENIED"        => "ACCESS_DENIED",
            "INSUFFICIENT_BALANCE" => "INSUFFICIENT_BALANCE",
            "NOT_FOUND"            => "NOT_FOUND",
            "INVALID_PARAMS"       => "INVALID_PARAMS",
            "INTERNAL_ERROR"       => "INTERNAL_ERROR",
            _ => status switch
            {
                HttpStatusCode.Unauthorized      => "UNAUTHORIZED",
                HttpStatusCode.Forbidden         => "FORBIDDEN",
                HttpStatusCode.NotFound          => "NOT_FOUND",
                (HttpStatusCode)429              => "RATE_LIMITED",
                >= HttpStatusCode.InternalServerError => "SERVER_ERROR",
                _ => "REQUEST_FAILED"
            }
        };
 
    public static string BuildUrl(string path, IEnumerable<(string key, string? value)> queryParams)
    {
        var filtered = queryParams.Where(p => p.value is not null).ToList();
        if (filtered.Count == 0) return path;
 
        var query = string.Join("&", filtered.Select(p =>
            $"{Uri.EscapeDataString(p.key)}={Uri.EscapeDataString(p.value!)}"));
        return $"{path}?{query}";
    }
}