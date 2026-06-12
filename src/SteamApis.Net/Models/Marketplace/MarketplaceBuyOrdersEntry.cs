using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Marketplace;

public sealed class MarketplaceBuyOrdersEntry : MarketplaceBuyOrder
{
    [JsonPropertyName("name")]
    public required string Name { get; init; }

    [JsonPropertyName("marketplace")]
    public required string Marketplace { get; init; }

    [JsonPropertyName("game")]
    public required string Game { get; init; }
}