using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieNight.Domain.Entities;

namespace MovieNight.Domain.Interfaces
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> GetMovies();
        Task<Movie> GetMovieById(string id);
        Task SaveMovie(Movie movie);
        Task DeleteMovie(string id);
    }
}
