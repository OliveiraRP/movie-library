using System.Threading.Tasks;

namespace MovieLibrary
{
    interface APIRequest
    {
        Task<string> requestMoviesAsync(string title);
        Task<string> requestMoviesAsync(string title, int year);
        Task<string> requestMovieAsync(string imdb);
    }
}
