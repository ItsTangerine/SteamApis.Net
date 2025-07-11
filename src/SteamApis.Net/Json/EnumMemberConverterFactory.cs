using System.Collections.Concurrent;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamApis.Net.Json;

public class EnumMemberConverterFactory : JsonConverterFactory
{
    private readonly ConcurrentDictionary<Type, JsonConverter> _converters = new();

    public override bool CanConvert(Type typeToConvert) => typeToConvert.IsEnum;

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        return _converters.GetOrAdd(typeToConvert, (type) =>
        {
            var converterType = typeof(EnumMemberStringConverter<>).MakeGenericType(type);
            return (JsonConverter)Activator.CreateInstance(converterType)!;
        });
    }
}