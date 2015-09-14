using System;
using System.Linq;
using MongoDB.Bson;
using MovieNight.Domain.Entities;
using MovieNight.Domain.Interfaces;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieNight.Domain.Repositories.MongoDb
{
    public class MoviesRepository : IMoviesRepository
    {
        private readonly MongoDbContext _context;

        public MoviesRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Movie>> GetMovies()
        {
            return await _context.Movies.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Movie> GetMovieById(string id)
        {
            return await _context.Movies.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task SaveMovie(Movie movie)
        {
            await _context.Movies.InsertOneAsync(movie);
        }

        public async Task DeleteMovie(string id)
        {
            await _context.Movies.FindOneAndDeleteAsync(x => x.Id == id);
        }
    }
}
