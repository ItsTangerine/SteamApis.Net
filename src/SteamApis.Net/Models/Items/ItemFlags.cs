using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Items;

public sealed class ItemFlags
{
    [JsonPropertyName("commodity")]
    public bool Commodity { get; init; }

    [JsonPropertyName("marketable")]
    public bool Marketable { get; init; }

    [JsonPropertyName("tradable")]
    public bool Tradable { get; init; }
}