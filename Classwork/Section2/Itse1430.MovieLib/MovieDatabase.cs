using System;
using System.Collections.Generic;

namespace Itse1430.MovieLib
{
    /// <summary>Manages a set of movies.</summary>
    public abstract class MovieDatabase
    {
        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        public void Add(Movie movie)
        {
            //TODO: Validate
            if (movie == null)
                return;

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
            //TODO: Validate
            if (String.IsNullOrEmpty(name))
                return;
            if (movie == null)
                return;

            //Find movie by name
            var existing = FindByName(name);
            if (existing == null)
                return;

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
