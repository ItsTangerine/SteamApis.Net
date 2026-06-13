using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamApis.Net.Json;

public class EnumMemberStringConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct, Enum
{
    private readonly ConcurrentDictionary<string, TEnum> _fromString = new();
    private readonly ConcurrentDictionary<TEnum, string> _toString = new();

    public EnumMemberStringConverter()
    {
        var type = typeof(TEnum);

        foreach (var field in type.GetFields(BindingFlags.Public | BindingFlags.Static))
        {
            var enumValue = (TEnum)field.GetValue(null)!;

            var enumMemberAttr = field.GetCustomAttribute<EnumMemberAttribute>();
            var name = enumMemberAttr?.Value ?? field.Name;

            _fromString[name] = enumValue;
            _toString[enumValue] = name;
        }
    }

    public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var enumString = reader.GetString();

            if (enumString is null || !_fromString.TryGetValue(enumString, out var enumValue))
                throw new JsonException($"Unknown enum value '{enumString}' for type '{typeof(TEnum)}'.");

            return enumValue;
        }

        if (reader.TokenType == JsonTokenType.Number)
        {
            var intValue = reader.GetInt32();
            return (TEnum)Enum.ToObject(typeof(TEnum), intValue);
        }

        if (reader.TokenType == JsonTokenType.False)
        {
            return default;
        }

        throw new JsonException($"Unexpected token {reader.TokenType} when parsing enum.");
    }

    public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
    {
        if (_toString.TryGetValue(value, out var name))
        {
            writer.WriteStringValue(name);
        }
        else
        {
            // Fallback: write numeric value as string
            writer.WriteStringValue(value.ToString());
        }
    }
}