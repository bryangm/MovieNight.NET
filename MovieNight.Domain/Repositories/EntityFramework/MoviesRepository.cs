using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight.Domain.Entities;
using MovieNight.Domain.Interfaces;

namespace MovieNight.Domain.Repositories.EntityFramework
{
    public class MoviesRepository : IMoviesRepository
    {
        public Task<Movie> DeleteCastMember(string movieId, string personId)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> DeleteDirector(string movieId, string personId)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> DeleteMovie(string movieId)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> DeleteWriter(string movieId, string personId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Movie>> FindAllMovies()
        {
            throw new NotImplementedException();
        }

        public Task<Movie> FindMovieById(string movieId)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> InsertCastMember(string movieId, Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> InsertDirector(string movieId, Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> InsertMovie(Movie movie)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> InsertWriter(string movieId, Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> UpdateMovie(string movieId, Movie movie)
        {
            throw new NotImplementedException();
        }
    }
}
