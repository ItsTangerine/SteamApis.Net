using System.Runtime.Serialization;

namespace SteamApis.Net.Models.Legacy.Market.Items;

public enum CompactValue
{
    [EnumMember(Value = "latest")]
    Latest,

    [EnumMember(Value = "min")]
    Min,

    [EnumMember(Value = "avg")]
    Avg,

    [EnumMember(Value = "max")]
    Max,

    [EnumMember(Value = "mean")]
    Mean,

    [EnumMember(Value = "safe")]
    Safe,

    [EnumMember(Value = "safe_ts.last_24h")]
    SafeTsLast24H,

    [EnumMember(Value = "safe_ts.last_7d")]
    SafeTsLast7Days,

    [EnumMember(Value = "safe_ts.last_30d")]
    SafeTsLast30Days,

    [EnumMember(Value = "safe_ts.last_90d")]
    SafeTsLast90Days,

    [EnumMember(Value = "unstable")]
    Unstable,

    [EnumMember(Value = "unstable_reason")]
    UnstableReason
}