using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Steam;

public sealed class Inventory
{
    [JsonPropertyName("assets")]
    public IReadOnlyList<InventoryAsset>? Assets { get; init; }
 
    [JsonPropertyName("descriptions")]
    public IReadOnlyList<ItemDescription>? Descriptions { get; init; }
}