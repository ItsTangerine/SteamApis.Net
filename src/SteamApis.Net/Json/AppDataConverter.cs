using System.Text.Json;
using System.Text.Json.Serialization;

namespace SteamApis.Net.Json;

public class AppDataConverter : JsonConverter<Dictionary<string, string>?>
{
    public override Dictionary<string, string>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String)
        {
            var str = reader.GetString();
            if (string.IsNullOrEmpty(str))
                return null; // or return new Dictionary<string, string>()
            throw new JsonException("Expected empty string or object for app_data.");
        }

        if (reader.TokenType == JsonTokenType.StartObject)
        {
            return JsonSerializer.Deserialize<Dictionary<string, string>>(ref reader, options);
        }

        throw new JsonException("Unexpected JSON token for app_data");
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, string>? value, JsonSerializerOptions options)
    {
        if (value == null)
        {
            writer.WriteStringValue("");
            return;
        }

        JsonSerializer.Serialize(writer, value, options);
    }
}