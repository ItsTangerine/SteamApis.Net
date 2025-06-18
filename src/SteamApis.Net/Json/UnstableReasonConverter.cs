using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;
using SteamApis.Net.Entities.Response.Market.Items;

namespace SteamApis.Net.Json;

public class UnstableReasonConverter : JsonConverter<UnstableReason>
{
    public override UnstableReason Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.False)
            return UnstableReason.None;

        if (reader.TokenType == JsonTokenType.String)
        {
            string? str = reader.GetString();

            foreach (var field in typeof(UnstableReason).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attr = field.GetCustomAttribute<EnumMemberAttribute>();
                if (attr?.Value == str)
                    return (UnstableReason)field.GetValue(null)!;
            }

            // Fallback: try parse
            if (Enum.TryParse<UnstableReason>(str, ignoreCase: true, out var parsed))
                return parsed;
        }

        throw new JsonException($"Invalid value for UnstableReason");
    }

    public override void Write(Utf8JsonWriter writer, UnstableReason value, JsonSerializerOptions options)
    {
        if (value == UnstableReason.None)
        {
            writer.WriteBooleanValue(false);
            return;
        }

        var enumMember = typeof(UnstableReason).GetMember(value.ToString())[0]
            .GetCustomAttribute<EnumMemberAttribute>();

        writer.WriteStringValue(enumMember?.Value ?? value.ToString());
    }
}