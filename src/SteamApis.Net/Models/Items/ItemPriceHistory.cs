using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class ItemPriceHistory
{
    [JsonPropertyName("data")]
    public required IReadOnlyList<ItemPricePoint> Data { get; init; }
}