using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Inventory;

public record InventoryResponse
{
    [JsonPropertyName("assets")]
    public List<Asset> Assets { get; init; } = [];

    [JsonPropertyName("descriptions")]
    public List<ItemDescription> Descriptions { get; init; } = [];

    [JsonPropertyName("total_inventory_count")]
    public int TotalInventoryCount { get; init; }

    [JsonPropertyName("success")]
    public int Success { get; init; }

    [JsonPropertyName("rwgrsn")]
    public int Rwgrsn { get; init; }
}