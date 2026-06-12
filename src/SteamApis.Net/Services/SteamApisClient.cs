using SteamApis.Net.Clients;

namespace SteamApis.Net.Services;

internal sealed class SteamApisClient(SteamApiClient steam, MarketPlaceApiClient marketPlace) : ISteamApisClient
{
    public SteamApiClient Steam { get; } = steam;
    
    public MarketPlaceApiClient MarketPlace { get; } = marketPlace;
}