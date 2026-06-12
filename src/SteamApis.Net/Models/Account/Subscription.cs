using System.Text.Json.Serialization;

namespace SteamApis.Net.Models.Account;

public sealed class Subscription
{
    [JsonPropertyName("planId")]
    public required string PlanId { get; init; }

    [JsonPropertyName("startDate")]
    public DateTimeOffset StartDate { get; init; }

    [JsonPropertyName("endDate")]
    public DateTimeOffset EndDate { get; init; }

    [JsonPropertyName("status")]
    public required string Status { get; init; }

    [JsonPropertyName("autoRenew")]
    public bool AutoRenew { get; init; }

    [JsonPropertyName("pendingPlanId")]
    public string? PendingPlanId { get; init; }

    [JsonPropertyName("pendingChangeType")]
    public string? PendingChangeType { get; init; }

    [JsonPropertyName("cycleStartDate")]
    public DateTimeOffset CycleStartDate { get; init; }

    [JsonPropertyName("nextRenewalDate")]
    public DateTimeOffset NextRenewalDate { get; init; }

    [JsonPropertyName("usage")]
    public Dictionary<string, long> Usage { get; init; } = [];

    [JsonPropertyName("billedOverage")]
    public decimal BilledOverage { get; init; }
}