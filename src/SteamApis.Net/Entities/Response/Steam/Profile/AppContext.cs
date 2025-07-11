using System.Text.Json.Serialization;
using SteamApis.Net.Json;

namespace SteamApis.Net.Entities.Response.Steam.Profile;

public record AppContext
{
    [JsonPropertyName("appid")]
    public int AppId { get; init; }

    [JsonPropertyName("name")]
    public string Name { get; init; } = null!;

    [JsonPropertyName("icon")]
    public string Icon { get; init; } = null!;

    [JsonPropertyName("link")]
    public string Link { get; init; } = null!;

    [JsonPropertyName("asset_count")]
    public int AssetCount { get; init; }

    [JsonPropertyName("inventory_logo")]
    public string InventoryLogo { get; init; } = null!;

    [JsonPropertyName("trade_permissions")]
    public string TradePermissions { get; init; } = null!;

    [JsonPropertyName("load_failed")]
    public int LoadFailed { get; init; }

    [JsonPropertyName("store_vetted")]
    [JsonConverter(typeof(StringBooleanConverter))]
    public bool? StoreVetted { get; init; }

    [JsonPropertyName("owner_only")]
    public bool OwnerOnly { get; init; }

    [JsonPropertyName("rgContexts")]
    public Dictionary<string, ContextDetail> RgContexts { get; init; } = [];
}
