using System.Collections.Generic;

namespace SpotMe.Services
{
    public interface ISpotifyService
    {
        LatestReleaseResponse GetNewReleases();
        Categories GetCategories();
        List<string> GetGenres();
        List<Track> GetRecommendations(List<string> genre, string artist);
    }

}