using System.Net;

namespace SteamApis.Net.Entities.Response;

public sealed record ApiResult<T>(
    bool IsSuccess,
    T? Value,
    string? Error,
    HttpStatusCode StatusCode)
{
    public static ApiResult<T> Success(T value, HttpStatusCode statusCode)
        => new(true, value, null, statusCode);

    public static ApiResult<T> Failure(string? error, HttpStatusCode statusCode)
        => new(false, default, error, statusCode);
    
    public bool TryGetValue(out T value)
    {
        value = Value!;
        return IsSuccess;
    }
    
    public T EnsureSuccess()
    {
        if (!IsSuccess)
            throw new HttpRequestException(Error);

        return Value!;
    }
}