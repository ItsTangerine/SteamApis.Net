using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamApis.Net.Json;

public class FlexibleDictionaryConverter<TValue> : JsonConverter<Dictionary<string, TValue>>
{
    public override Dictionary<string, TValue> Read(
        ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Steam returns [] instead of {} when empty — handle both
        if (reader.TokenType == JsonTokenType.StartArray)
        {
            // Consume the array tokens and return empty dict
            using var doc = JsonDocument.ParseValue(ref reader);
            return [];
        }

        if (reader.TokenType == JsonTokenType.StartObject)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            var result = new Dictionary<string, TValue>();

            foreach (var prop in doc.RootElement.EnumerateObject())
            {
                var value = prop.Value.Deserialize<TValue>(options);
                if (value is not null)
                    result[prop.Name] = value;
            }

            return result;
        }

        throw new JsonException($"Unexpected token: {reader.TokenType}");
    }

    public override void Write(
        Utf8JsonWriter writer, Dictionary<string, TValue> value, JsonSerializerOptions options)
        => JsonSerializer.Serialize(writer, value, options);
}