# SteamApis.Net

Unofficial https://steamapis.com .NET library, supporting .NET 6.0+

```bash
dotnet add package SteamApis.Net
```

## Usage

For Dependency Injection (ASP.NET Core or Generic Host)

```csharp
builder.Services.AddSteamApis(options =>
{
    options.ApiKey = "your-steamapis-key";
    options.BaseUrl = "https://api.steamapis.com/";
});
```

Without Dependency Injection

```csharp
var apiClient = SteamApisClient.Create(new SteamApisOptions()
{
    ApiKey = "your-steamapis-key",
    BaseUrl = "https://api.steamapis.com/"
});

var inventory = await apiClient.GetUserSteamInventory("7656119...", 730, 2);
```
