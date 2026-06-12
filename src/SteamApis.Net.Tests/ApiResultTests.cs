using SteamApis.Net.Models.Response;

namespace SteamApis.Net.Tests;

public sealed class ApiResultTests
{
    [Fact]
    public void Ok_IsSuccess_True()
    {
        var result = ApiResult<string>.Ok("hello");

        Assert.True(result.IsSuccess);
        Assert.False(result.IsFailure);
    }

    [Fact]
    public void Ok_Value_ReturnsPayload()
    {
        var result = ApiResult<int>.Ok(42);

        Assert.Equal(42, result.Value);
    }

    [Fact]
    public void Ok_Error_IsNull()
    {
        var result = ApiResult<string>.Ok("x");

        Assert.Null(result.Error);
    }

    [Fact]
    public void Fail_IsFailure_True()
    {
        var result = ApiResult<string>.Fail(404, "NOT_FOUND", "Item not found");

        Assert.True(result.IsFailure);
        Assert.False(result.IsSuccess);
    }

    [Fact]
    public void Fail_Error_PopulatedCorrectly()
    {
        var result = ApiResult<string>.Fail(401, "UNAUTHORIZED", "Bad key");

        Assert.Equal(401, result.Error!.StatusCode);
        Assert.Equal("UNAUTHORIZED", result.Error.Code);
        Assert.Equal("Bad key", result.Error.Message);
    }

    [Fact]
    public void Fail_AccessingValue_Throws()
    {
        var result = ApiResult<string>.Fail(500, "SERVER_ERROR", "Oops");

        Assert.Throws<InvalidOperationException>(() => _ = result.Value);
    }

    [Fact]
    public void TryGetValue_OnSuccess_ReturnsTrueAndValue()
    {
        var result = ApiResult<string>.Ok("world");

        var ok = result.TryGetValue(out var value);

        Assert.True(ok);
        Assert.Equal("world", value);
    }

    [Fact]
    public void TryGetValue_OnFailure_ReturnsFalse()
    {
        var result = ApiResult<string>.Fail(403, "FORBIDDEN", "No access");

        var ok = result.TryGetValue(out _);

        Assert.False(ok);
    }

    [Fact]
    public void GetValueOrDefault_OnSuccess_ReturnsValue()
    {
        var result = ApiResult<int>.Ok(7);

        Assert.Equal(7, result.GetValueOrDefault(-1));
    }

    [Fact]
    public void GetValueOrDefault_OnFailure_ReturnsFallback()
    {
        var result = ApiResult<int>.Fail(404, "NOT_FOUND", "Missing");

        Assert.Equal(-1, result.GetValueOrDefault(-1));
    }

    [Fact]
    public void Map_OnSuccess_TransformsValue()
    {
        var result = ApiResult<int>.Ok(5).Map(x => x * 2);

        Assert.True(result.IsSuccess);
        Assert.Equal(10, result.Value);
    }

    [Fact]
    public void Map_OnFailure_PropagatesError()
    {
        var original = ApiResult<int>.Fail(400, "INVALID_PARAMS", "Bad request");
        var mapped   = original.Map(x => x.ToString());

        Assert.True(mapped.IsFailure);
        Assert.Equal("INVALID_PARAMS", mapped.Error!.Code);
    }

    [Fact]
    public void OnSuccess_CalledOnlyWhenSuccessful()
    {
        var called = false;
        ApiResult<string>.Ok("hi").OnSuccess(_ => called = true);

        Assert.True(called);
    }

    [Fact]
    public void OnSuccess_NotCalledOnFailure()
    {
        var called = false;
        ApiResult<string>.Fail(500, "ERR", "fail").OnSuccess(_ => called = true);

        Assert.False(called);
    }

    [Fact]
    public void OnFailure_CalledOnlyWhenFailed()
    {
        var called = false;
        ApiResult<string>.Fail(404, "NOT_FOUND", "Missing").OnFailure(_ => called = true);

        Assert.True(called);
    }

    [Fact]
    public void OnFailure_NotCalledOnSuccess()
    {
        var called = false;
        ApiResult<string>.Ok("ok").OnFailure(_ => called = true);

        Assert.False(called);
    }

    [Fact]
    public void ImplicitConversion_FromValue_CreatesSuccessResult()
    {
        ApiResult<string> result = "implicit";

        Assert.True(result.IsSuccess);
        Assert.Equal("implicit", result.Value);
    }

    [Fact]
    public void ToString_OnSuccess_ContainsOk()
    {
        var result = ApiResult<int>.Ok(1);

        Assert.Contains("Ok", result.ToString());
    }

    [Fact]
    public void ToString_OnFailure_ContainsFail()
    {
        var result = ApiResult<string>.Fail(400, "BAD", "err");

        Assert.Contains("Fail", result.ToString());
    }
}