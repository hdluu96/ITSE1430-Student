using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Itse1430.MovieLib
{
    public static class SeedDatabase
    {
        public static void Seed (MovieDatabase database)
        {
            var movies = new[] {
                new Movie() {
                    Name = "Jaws",
                    RunLength = 120,
                    ReleaseYear = 1977,
                },
                new Movie() {
                    Name = "What About Bob?",
                    RunLength = 96,
                    ReleaseYear = 2004,
                },
            };
            Seed(database, movies);
        }

        public static void Seed (MovieDatabase database, Movie[] movies)
        {
            foreach (var movie in movies)
                database.Add(movie);
        }
    }
}
