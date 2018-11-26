﻿/*
 * ITSE1430
 */
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
            if (movie == null)
                throw new ArgumentNullException("movie");
            ObjectValidator.Validate(movie);

            //if (movie == null) return;

            try
            {
                AddCore(movie);
            }
            catch (Exception e)
            {
                throw new Exception("Add failed", e);
            };
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of movies.</returns>
        public IEnumerable<Movie> GetAll()
        {
            return GetAllCore();
        }

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

        /// <summary>Removes a movie.</summary>
        /// <param name="name">The movie to remove.</param>
        public void Remove(string name)
        {
            //Validate
            if (name == null)
                throw new ArgumentNullException(nameof(name));
            else if (name == "")
                throw new ArgumentException("Name cannot be empty.", nameof(name));

            RemoveCore(name);
        }

        #region Protected Members

        /// <summary>Adds a movie.</summary>
        /// <param name="movie">The movie to add.</param>
        protected abstract void AddCore(Movie movie);

        /// <summary>Edits a movie.</summary>
        /// <param name="oldMovie">The old movie.</param>
        /// <param name="newMovie">The new movie.</param>
        protected abstract void EditCore(Movie oldMovie, Movie newMovie);

        /// <summary>Finds a movie by name.</summary>
        /// <param name="name">The name of the movie.</param>
        /// <returns>The movie, if any.</returns>
        protected abstract Movie FindByName(string name);

        /// <summary>Gets all the movies.</summary>
        /// <returns>The list of movies.</returns>
        protected abstract IEnumerable<Movie> GetAllCore();

        /// <summary>Removes a movie.</summary>
        /// <param name="name">The name of the movie.</param>
        protected abstract void RemoveCore(string name);
        #endregion
    }
}
