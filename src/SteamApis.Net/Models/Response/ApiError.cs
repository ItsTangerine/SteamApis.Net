namespace SteamApis.Net.Models.Response;

/// <summary>
/// Structured error returned inside a <see cref="ApiResult{T}"/> on failure.
/// </summary>
public sealed record ApiError(int StatusCode, string? Code, string? Message)
{
    public override string ToString() => $"[{StatusCode}] {Code}: {Message}";
}