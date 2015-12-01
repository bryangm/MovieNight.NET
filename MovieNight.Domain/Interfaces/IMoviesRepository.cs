using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieNight.Domain.Entities;

namespace MovieNight.Domain.Interfaces
{
    public interface IMoviesRepository
    {
        Task<List<Movie>> FindAllMovies();
        Task<Movie> FindMovieById(int movieId);
        Task<Movie> InsertMovie(Movie movie);
        Task<Movie> UpdateMovie(int movieId, Movie movie);
        Task<Movie> DeleteMovie(int movieId);
        Task<Genre> InsertGenre(int movieId, string genre);
        Task<Genre> DeleteGenre(int movieId, int genreId);
        Task<Director> InsertDirector(int movieId, Director director);
        Task<Director> DeleteDirector(int movieId, int directorId);
        Task<Writer> InsertWriter(int movieId, Writer writer);
        Task<Writer> DeleteWriter(int movieId, int writerId);
        Task<CastMember> InsertCastMember(int movieId, CastMember castMember);
        Task<CastMember> DeleteCastMember(int movieId, int castMemberId);
    }
}
