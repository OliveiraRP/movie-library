using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieLibrary
{
    class MovieCollection
    {
        private List<Movie> movies;

        public MovieCollection()
        {
            movies = new List<Movie> { };
        }

        public List<Movie> Movies { get => movies; set => movies = value; }

        public async Task searchMovies(string title)
        {
            APIImdb api = new APIImdb();

            string rawJson = await api.requestMoviesAsync(title);
            var req = JsonConvert.DeserializeObject<dynamic>(rawJson);

            string response = req.Response;
            if (!response.Equals("True"))
                return;

            foreach (var movie in req.Search)
            {
                string movTitle = movie.Title, movYear = movie.Year, movImdbId = movie.imdbID, movPoster = movie.Poster;
                Movie m = new Movie(movTitle, movYear, movImdbId, movPoster);
                Movies.Add(m);
            }
        }
    }
}
