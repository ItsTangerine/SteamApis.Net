using SteamApis.Net.Models.Response;
using SteamApis.Net.Models.SteamApis;

namespace SteamApis.Net.Tests.Helpers;

public static class AssertHelpers
{
    internal static void AssertSuccess<T>(ApiResult<T> result)
    {
        Assert.True(result.IsSuccess,
            $"Expected success but got: [{result.Error?.StatusCode}] {result.Error?.Code} — {result.Error?.Message}");
    }

    internal static void AssertPagedHasResults<T>(PagedApiResponse<T> paged)
    {
        Assert.NotNull(paged.Results);
        Assert.NotEmpty(paged.Results!);
    }
}