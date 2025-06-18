using System.Text.Json;

namespace SteamApis.Net.Json;

public class JsonNamingPolicyDecorator : JsonNamingPolicy 
{
    private readonly JsonNamingPolicy? _underlyingNamingPolicy;
    
    public JsonNamingPolicyDecorator(JsonNamingPolicy? underlyingNamingPolicy) => _underlyingNamingPolicy = underlyingNamingPolicy;
    public override string ConvertName (string name) => _underlyingNamingPolicy?.ConvertName(name) ?? name;
}