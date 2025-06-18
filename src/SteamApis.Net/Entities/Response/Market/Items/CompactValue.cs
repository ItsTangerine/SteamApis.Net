using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Items;

[JsonConverter(typeof(JsonStringEnumConverter))]
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
    SafeTsLast7d,

    [EnumMember(Value = "safe_ts.last_30d")]
    SafeTsLast30d,

    [EnumMember(Value = "safe_ts.last_90d")]
    SafeTsLast90d,

    [EnumMember(Value = "unstable")]
    Unstable,

    [EnumMember(Value = "unstable_reason")]
    UnstableReason
}