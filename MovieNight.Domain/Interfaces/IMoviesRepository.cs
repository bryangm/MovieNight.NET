using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieNight.Domain.Entities;

namespace MovieNight.Domain.Interfaces
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> FindAllMovies();
        Task<Movie> FindMovieById(string movieId);
        Task<Movie> InsertMovie(Movie movie);
        Task<Movie> UpdateMovie(string movieId, Movie movie);
        Task<Movie> DeleteMovie(string movieId);
        Task<Movie> InsertDirector(string movieId, Person person);
        Task<Movie> DeleteDirector(string movieId, string personId);
        Task<Movie> InsertWriter(string movieId, Person person);
        Task<Movie> DeleteWriter(string movieId, string personId);
        Task<Movie> InsertCastMember(string movieId, Person person);
        Task<Movie> DeleteCastMember(string movieId, string personId);

    }
}
