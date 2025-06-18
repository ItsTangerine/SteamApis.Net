using System.Runtime.Serialization;

namespace SteamApis.Net.Extensions;

public static class EnumEx
{
    public static string GetEnumMemberValue(this Enum enumValue)
    {
        var enumType = enumValue.GetType();
        var member = enumType.GetMember(enumValue.ToString()).FirstOrDefault();
        var attribute = member?.GetCustomAttributes(typeof(EnumMemberAttribute), false)
            .Cast<EnumMemberAttribute>()
            .FirstOrDefault();

        return attribute?.Value ?? enumValue.ToString();
    }
}