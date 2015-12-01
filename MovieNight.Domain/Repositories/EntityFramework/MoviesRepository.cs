using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MovieNight.Domain.Entities;
using MovieNight.Domain.Enums;
using MovieNight.Domain.Interfaces;

namespace MovieNight.Domain.Repositories.EntityFramework
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly EntityFrameworkDbContext _context;

        public MoviesRepository(EntityFrameworkDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> FindAllMovies()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<Movie> FindMovieById(int movieId)
        {
            return await _context.Movies.FindAsync(movieId);
        }

        public async Task<Movie> InsertMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> UpdateMovie(int movieId, Movie movie)
        {
            var movieToUpdate = await _context.Movies.FindAsync(movieId);

            if (movieToUpdate == null) return null;

            movieToUpdate.Title = movie.Title;
            movieToUpdate.Year = movie.Year;
            movieToUpdate.Rating = movie.Rating;
            movieToUpdate.Length = movie.Length;
            movieToUpdate.ReleaseDate = movie.ReleaseDate;
            await _context.SaveChangesAsync();
            return movie;
        }

        public async Task<Movie> DeleteMovie(int movieId)
        {
            var movieToDelete = await _context.Movies.FindAsync(movieId);

            if (movieToDelete == null) return null;

            _context.Movies.Remove(movieToDelete);
            await _context.SaveChangesAsync();
            return movieToDelete;
        }

        public async Task<Genre> InsertGenre(int movieId, string genre)
        {
            var genreToAdd = new Genre
            {
                Category = (GenreCategory) Enum.Parse(typeof (GenreCategory), genre)
            };

            var movieToUpdate = await _context.Movies.FindAsync(movieId);

            if (movieToUpdate == null) return null;

            movieToUpdate.Genres.Add(genreToAdd);
            await _context.SaveChangesAsync();
            return genreToAdd;
        }

        public async Task<Genre> DeleteGenre(int movieId, int genreId)
        {
            var movieToUpdate = await _context.Movies.FindAsync(movieId);
            var genreToDelete = movieToUpdate?.Genres.Find(x => x.GenreId == genreId);

            if (genreToDelete == null) return null;

            movieToUpdate.Genres.RemoveAll(x => x.GenreId == genreId);
            await _context.SaveChangesAsync();
            return genreToDelete;              
        }

        public async Task<Director> InsertDirector(int movieId, Director director)
        {
            var movieToUpdate = await _context.Movies.FindAsync(movieId);

            if (movieToUpdate == null) return null;

            movieToUpdate.Directors.Add(director);
            await _context.SaveChangesAsync();
            return director;
        }

        public async Task<Director> DeleteDirector(int movieId, int directorId)
        {
            var movieToUpdate = await _context.Movies.FindAsync(movieId);
            var directorToDelete = movieToUpdate?.Directors.Find(x => x.DirectorId == directorId);

            if (directorToDelete == null) return null;

            movieToUpdate.Directors.RemoveAll(x => x.DirectorId == directorId);
            await _context.SaveChangesAsync();
            return directorToDelete;
        }

        public async Task<Writer> InsertWriter(int movieId, Writer writer)
        {
            var movieToUpdate = await _context.Movies.FindAsync(movieId);

            if (movieToUpdate == null) return null;

            movieToUpdate.Writers.Add(writer);
            await _context.SaveChangesAsync();
            return writer;
        }

        public async Task<Writer> DeleteWriter(int movieId, int writerId)
        {
            var movieToUpdate = await _context.Movies.FindAsync(movieId);
            var writerToDelete = movieToUpdate?.Writers.Find(x => x.WriterId == writerId);

            if (writerToDelete == null) return null;

            movieToUpdate.Writers.RemoveAll(x => x.WriterId == writerId);
            await _context.SaveChangesAsync();
            return writerToDelete;
        }
        public async Task<CastMember> InsertCastMember(int movieId, CastMember castMember)
        {
            var movieToUpdate = await _context.Movies.FindAsync(movieId);

            if (movieToUpdate == null) return null;

            movieToUpdate.CastMembers.Add(castMember);
            await _context.SaveChangesAsync();
            return castMember;
        }

        public async Task<CastMember> DeleteCastMember(int movieId, int castMemberId)
        {
            var movieToUpdate = await _context.Movies.FindAsync(movieId);
            var castMemberToDelete = movieToUpdate?.CastMembers.Find(x => x.CastMemberId == castMemberId);

            if (castMemberToDelete == null) return null;

            movieToUpdate.CastMembers.RemoveAll(x => x.CastMemberId == castMemberId);
            await _context.SaveChangesAsync();
            return castMemberToDelete;
        }
    }
}
