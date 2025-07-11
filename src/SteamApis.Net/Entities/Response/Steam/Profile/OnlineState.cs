using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace SteamApis.Net.Entities.Response.Steam.Profile;

public enum OnlineState
{
    [EnumMember(Value = "offline")]
    Offline,

    [EnumMember(Value = "online")]
    Online,

    [EnumMember(Value = "in-game")]
    InGame,

    [EnumMember(Value = "away")]
    Away,

    [EnumMember(Value = "snooze")]
    Snooze,

    [EnumMember(Value = "busy")]
    Busy,

    [EnumMember(Value = "looking to trade")]
    LookingToTrade,

    [EnumMember(Value = "looking to play")]
    LookingToPlay
}