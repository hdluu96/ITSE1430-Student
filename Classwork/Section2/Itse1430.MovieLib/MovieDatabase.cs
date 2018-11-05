using System;
using System.Collections.Generic;

namespace Itse1430.MovieLib
{
    /// <summary>Manages a set of movies.</summary>
    public abstract class MovieDatabase : IMovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        public void Add(Movie movie)
        {
            //Validate
            if(movie == null)
                throw new ArgumentNullException("movie");
            ObjectValidator.Validate(movie);

            //if (movie == null) return;


            AddCore(movie);
        }

        protected abstract void AddCore(Movie movie);

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of movies.</returns>
        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }

        protected abstract IEnumerable<Movie> GetAllCore();

        /// <summary>Edits an existing movie.</summary>
        /// <param name="name">The movie to edit.</param>
        /// <param name="movie">The new movie.</param>
        public void Edit(string name, Movie movie)
        {
            //Validate
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            else if (name == "")
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            ObjectValidator.Validate(movie);

            //Find movie by name
            var existing = FindByName(name);
            if (existing == null)
                throw new Exception("Movie not found.");

            EditCore(existing, movie);
        }

        protected abstract Movie FindByName(string name);

        protected abstract void EditCore(Movie oldMovie, Movie newMovie);

        /// <summary>Removes a movie.</summary>
        /// <param name="name">The movie to remove.</param>
        public void Remove(string name)
        {
            //TODO: Validate
            if (String.IsNullOrEmpty(name))
                return;

            RemoveCore(name);
        }

        protected abstract void RemoveCore(string name);
    }
}
