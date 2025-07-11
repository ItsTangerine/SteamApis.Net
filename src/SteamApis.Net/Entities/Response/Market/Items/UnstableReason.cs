using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Market.Items;

public enum UnstableReason
{
    [EnumMember(Value = "NONE")]
    None,
    
    // No sales
    [EnumMember(Value = "NO_SALES_WEEK")]
    NoSalesWeek,

    [EnumMember(Value = "NO_SALES_MONTH")]
    NoSalesMonth,

    [EnumMember(Value = "NO_SALES_3PLUS_MONTHS")]
    NoSales3PlusMonths,

    [EnumMember(Value = "NO_SALES_OVERALL")]
    NoSalesOverall,

    // Low sales
    [EnumMember(Value = "LOW_SALES_WEEK")]
    LowSalesWeek,

    [EnumMember(Value = "LOW_SALES_MONTH")]
    LowSalesMonth,

    [EnumMember(Value = "LOW_SALES_3PLUS_MONTHS")]
    LowSales3PlusMonths,

    [EnumMember(Value = "LOW_SALES_OVERALL")]
    LowSalesOverall
}