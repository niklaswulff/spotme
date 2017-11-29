using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace SpotMe.Services
{
    public class SpotifyService : ISpotifyService
    {
        private static string access_token;
        private static DateTime expiryDate;

        private WebClient GetWebClient()
        {
            var token = GetToken();
            var webClient = new WebClient
            {
                Encoding = Encoding.UTF8,
                Headers = {[HttpRequestHeader.Authorization] = "Bearer " + token}
            };

            return webClient;
        }

        public LatestReleaseResponse GetNewReleases()
        {
            using (var wc = GetWebClient())
            {
                var address = "https://api.spotify.com/v1/browse/new-releases";
                
                var result = wc.DownloadString(address);

                var albumResult = JsonConvert.DeserializeObject<LatestReleaseResponse>(result);

                return albumResult;
            }
        }

        public Categories GetCategories()
        {
            using (var wc = GetWebClient())
            {
                var address = "https://api.spotify.com/v1/browse/categories";

                var result = wc.DownloadString(address);

                var categories = JsonConvert.DeserializeObject<CategoriesResponse>(result);

                return categories.categories;
            }
        }
        
        public List<string> GetGenres()
        {
            using (var wc = GetWebClient())
            {
                var address = "https://api.spotify.com/v1/recommendations/available-genre-seeds";

                var result = wc.DownloadString(address);

                var categories = JsonConvert.DeserializeObject<GenresResponse>(result);

                return categories.genres;
            }
        }

        public List<Track> GetRecommendations(List<string> genre, string artist)
        {
            using (var wc = GetWebClient())
            {
                var queryString = HttpUtility.ParseQueryString(string.Empty);

                queryString["seed_genres"] = string.Join(",", genre.Take(5));
                queryString["seed_artists"] = artist;

                var address = $"https://api.spotify.com/v1/recommendations?{queryString}";

                var result = wc.DownloadString(address);

                var categories = JsonConvert.DeserializeObject<RecommendationsResponse>(result);

                return categories.tracks;
            }
        }

        private string GetToken()
        {
            if (DateTime.Now <= expiryDate)
            {
                return access_token;
            }

            using (var wc = new WebClient())
            {
                var URI = "https://accounts.spotify.com/api/token";
                var myParameters = "grant_type=client_credentials";

                var clientId = "996d0037680544c987287a9b0470fdbb";
                var clientSecret = "5a3c92099a324b8f9e45d77e919fec13";

                var svcCredentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(clientId + ":" + clientSecret));

                wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                wc.Headers[HttpRequestHeader.Authorization] = "Basic " + svcCredentials;

                var result = wc.UploadString(URI, myParameters);

                var token = JsonConvert.DeserializeObject<Token>(result);
                access_token = token.access_token;
                expiryDate = DateTime.Now.AddSeconds(token.expires_in);

                return access_token;
            }
        }
    }
}
