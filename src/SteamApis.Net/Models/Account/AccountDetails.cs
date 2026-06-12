using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Account;

public sealed class AccountDetails
{
    [JsonPropertyName("balance")]
    public double Balance { get; init; }

    [JsonPropertyName("overageEnabled")]
    public bool OverageEnabled { get; init; }

    [JsonPropertyName("overageSpendingLimit")]
    public decimal OverageSpendingLimit { get; init; }

    [JsonPropertyName("subscriptions")]
    public Dictionary<string, Subscription>? Subscriptions { get; init; }
}