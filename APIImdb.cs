using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieLibrary
{
    class APIImdb : APIRequest
    {
        public async Task<string> requestMoviesAsync(string title)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://movie-database-imdb-alternative.p.rapidapi.com/?s=" + WebUtility.UrlEncode(title) + "&page=1&type=movie&r=json"),
                Headers =
    {
        { "x-rapidapi-key", APIKeys.RapidApi },
        { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }


        public async Task<string> requestMoviesAsync(string title, int year)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://movie-database-imdb-alternative.p.rapidapi.com/?s=" + WebUtility.UrlEncode(title) + "&page=1&y=" + year.ToString() + "&type=movie&r=json"),
                Headers =
    {
        { "x-rapidapi-key", APIKeys.RapidApi },
        { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }

        public async Task<string> requestMovieAsync(string imdb)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://movie-database-imdb-alternative.p.rapidapi.com/?i=" + imdb + "&r=json"),
                Headers =
    {
        { "x-rapidapi-key", APIKeys.RapidApi },
        { "x-rapidapi-host", "movie-database-imdb-alternative.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                return body;
            }
        }
    }
}
