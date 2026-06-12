# SteamApis.Net
[![NuGet](https://img.shields.io/nuget/v/SteamApis.Net.svg)](https://www.nuget.org/packages/SteamApis.Net/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](https://opensource.org/licenses/MIT)

Unofficial https://steamapis.com .NET library, targeting .NET 8.0

```bash
dotnet add package SteamApis.Net
```

## Getting started

### Dependency Injection (ASP.NET Core or Generic Host)

```csharp
using SteamApis.Net.Extensions;

builder.Services.AddSteamApis("your-steamapis-key");
```

You can optionally customize the underlying `HttpClient`:

```csharp
builder.Services.AddSteamApis("your-steamapis-key", client =>
{
    client.Timeout = TimeSpan.FromSeconds(30);
});
```

Then inject `ISteamApisClient` anywhere:

```csharp
public class MyService(ISteamApisClient steamApis)
{
    public async Task DoWorkAsync()
    {
        var inventory = await steamApis.Steam.Users.GetInventoryAsync("7656119...", 730, 2);
    }
}
```

### Standalone (no DI)

```csharp
using SteamApis.Net.Services;

var client = SteamApisClientFactory.Create("your-steamapis-key");

var inventory = await client.Steam.Users.GetInventoryAsync("7656119...", 730, 2);
```

## Client structure

`ISteamApisClient` exposes two API groups:

| Property      | Base URL                               | Description                         |
|---------------|----------------------------------------|-------------------------------------|
| `Steam`       | `https://api.steamapis.com`            | Steam API v2 endpoints              |
| `MarketPlace` | `https://marketplaceapi.steamapis.com` | Third-party Marketplace Data API v2 |

## Error handling

Every method returns an `ApiResult<T>` — no exceptions are thrown for API-level failures:

```csharp
var result = await client.Steam.Apps.GetDetailsAsync(730);

if (result.IsSuccess)
{
    Console.WriteLine(result.Value.Name);
}
else
{
    Console.WriteLine($"{result.Error.StatusCode}: {result.Error.Message}");
}
```

`ApiResult<T>` also provides helpers like `TryGetValue`, `GetValueOrDefault`, `Map`, `OnSuccess`, and `OnFailure`:

```csharp
var playerCount = (await client.Steam.Apps.GetPlayerCountsAsync())
    .OnFailure(error => logger.LogWarning("Request failed: {Code}", error.Code));
```
