namespace SteamApis.Net.Models.App;

public sealed class RatingEntry
{
    public required string Rating { get; init; }
    
    public required string Descriptors { get; init; }
}