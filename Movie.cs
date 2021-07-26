using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace MovieLibrary
{
    class Movie
    {
        public string Title { get; private set; }
        public string Year { get; private set; }
        public string imdbID { get; private set; }
        public string Poster { get; private set; }
        public string Rated { get; private set; }
        public string Released { get; private set; }
        public string Runtime { get; private set; }
        public string Genre { get; private set; }
        public string Director { get; private set; }
        public string Writer { get; private set; }
        public string Actor { get; private set; }
        public string Plot { get; private set; }
        public string Country { get; private set; }
        public string Metascore { get; private set; }
        public string imdbRating { get; private set; }
        public string Production { get; private set; }
        public string BoxOffice { get; private set; }

        public Movie() { }

        [JsonConstructor]
        public Movie(string title, string year, string imdbid, string poster, string rated, string released, string runtime, string genre, string director, string writer,
                     string actor, string plot, string country, string metascore, string imdbrating, string production, string boxoffice)
        {
            Title = title; Year = year; imdbID = imdbid; Poster = poster; Rated = rated; Released = released; Runtime = runtime; Genre = genre; Director = director; Writer = writer;
            Actor = actor; Plot = plot; Country = country; Metascore = metascore; imdbRating = imdbrating; Production = production; BoxOffice = boxoffice;
        }

        public Movie(string imdbId)
        {
            imdbID = imdbId;
        }

        public Movie(string title, string year, string imdbId, string poster)
        {
            Title = title;
            Year = year;
            imdbID = imdbId;
            Poster = poster;
        }

        public async Task<Movie> getMovie(string imdb)
        {
            APIImdb api = new APIImdb();

            string rawJson = await api.requestMovieAsync(imdb);
            Movie mov = JsonConvert.DeserializeObject<Movie>(rawJson);

            return mov;
        }
    }
}
