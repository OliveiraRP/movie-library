using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MovieLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            bool menu = true;
            while (menu)
            {
                menu = MainMenu();
            }
        }

        private static bool MainMenu()
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1) Search movie");
            Console.WriteLine("2) Show favorites");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.Write("[Search movie]");
                    SearchMovie();
                    return true;
                case "2":
                    Console.Clear();
                    Console.WriteLine("Not implemented");
                    return false;
                default:
                    return false;
            }
        }

        private static bool MovieMenu(Movie movie)
        {
            Console.Clear();
            Console.WriteLine(movie.Title);
            Console.WriteLine("Release date: " + movie.Released);
            Console.WriteLine("Runtime: " + movie.Runtime);
            Console.WriteLine("Genre: " + movie.Genre);
            Console.WriteLine("Director: " + movie.Director);
            Console.WriteLine("IMDb rating: " + movie.imdbRating);

          Console.WriteLine("\nChoose an option:");
            Console.WriteLine("1) Add to favorites");
            Console.WriteLine("2) Return to main menu");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("Not implemented");
                    return false;
                case "2":
                    return false;
                default:
                    return false;
            }
        }

        private static void SearchMovie()
        {
            Console.Write("\nEnter movie title: ");
            string title = Console.ReadLine();

            MovieCollection mC = new MovieCollection();

            Task t1 = mC.searchMovies(title);
            t1.Wait();

            if (mC.Movies.Count == 0)
            {
                Console.WriteLine("\nNo movies found with title \"" + title + "\"");
                SearchMovie();
            }

            Console.WriteLine("\nResults: ");
            int nResult = 1;
            foreach (Movie m in mC.Movies)
            {
                Console.WriteLine(nResult + ") " + m.Title);
                nResult++;
            }

            Console.Write("\nChoose movie: ");
            string movie = Console.ReadLine();

            Movie aux = new Movie();
            Task<Movie> t2 = aux.getMovie(mC.Movies[int.Parse(movie) - 1].imdbID);
            t2.Wait();
            Movie extMovie = t2.Result;

            bool movieMenu = true;
            while (movieMenu)
            {
                movieMenu = MovieMenu(extMovie);
            }
        }
    }
}