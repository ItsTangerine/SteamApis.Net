namespace SteamApis.Net.Models.Response;

/// <summary>
/// Discriminated union that represents either a successful value or an API error.
/// No exception is thrown for API-level failures — inspect <see cref="IsSuccess"/> first.
/// </summary>
/// <typeparam name="T">The payload type on success.</typeparam>
public sealed class ApiResult<T>
{
    private readonly T? _value;
 
    private ApiResult(T value)
    {
        _value = value;
        IsSuccess = true;
    }
 
    private ApiResult(ApiError error)
    {
        Error = error;
        IsSuccess = false;
    }
 
    /// <summary>True when the call succeeded and <see cref="Value"/> is populated.</summary>
    public bool IsSuccess { get; }
 
    /// <summary>True when the call failed and <see cref="Error"/> is populated.</summary>
    public bool IsFailure => !IsSuccess;
 
    /// <summary>
    /// The response payload. Throws <see cref="InvalidOperationException"/> if accessed on a failure result.
    /// Always check <see cref="IsSuccess"/> (or use <see cref="TryGetValue"/>) before reading this.
    /// </summary>
    public T Value => IsSuccess
        ? _value!
        : throw new InvalidOperationException(
            $"Cannot access Value on a failed Result. Error: {Error?.Code} — {Error?.Message}");
 
    /// <summary>Error details when <see cref="IsFailure"/> is true; otherwise null.</summary>
    public ApiError? Error { get; }
 
    /// <summary>Tries to get the value without throwing. Returns false on failure.</summary>
    public bool TryGetValue(out T value)
    {
        value = _value!;
        return IsSuccess;
    }
 
    /// <summary>Returns the value if successful, or <paramref name="fallback"/> on failure.</summary>
    public T GetValueOrDefault(T fallback) => IsSuccess ? _value! : fallback;
 
    /// <summary>Transforms the value with <paramref name="map"/> when successful; propagates the error otherwise.</summary>
    public ApiResult<TOut> Map<TOut>(Func<T, TOut> map)
        => IsSuccess ? ApiResult<TOut>.Ok(map(_value!)) : ApiResult<TOut>.Fail(Error!);
 
    /// <summary>Runs <paramref name="action"/> against the value when successful.</summary>
    public ApiResult<T> OnSuccess(Action<T> action)
    {
        if (IsSuccess) action(_value!);
        return this;
    }
 
    /// <summary>Runs <paramref name="action"/> against the error when failed.</summary>
    public ApiResult<T> OnFailure(Action<ApiError> action)
    {
        if (IsFailure) action(Error!);
        return this;
    }
 
    /// <summary>Creates a successful result wrapping <paramref name="value"/>.</summary>
    public static ApiResult<T> Ok(T value) => new(value);
 
    /// <summary>Creates a failed result from an <see cref="ApiError"/>.</summary>
    public static ApiResult<T> Fail(ApiError error) => new(error);
 
    /// <summary>Creates a failed result from raw parts.</summary>
    public static ApiResult<T> Fail(int statusCode, string? code, string? message)
        => new(new ApiError(statusCode, code, message));
 
    /// <summary>Implicitly wraps a value in a successful result.</summary>
    public static implicit operator ApiResult<T>(T value) => Ok(value);
 
    public override string ToString() =>
        IsSuccess ? $"Ok({_value})" : $"Fail({Error?.Code}: {Error?.Message})";
}