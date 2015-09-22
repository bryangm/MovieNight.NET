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

        public async Task<Movie> GetMovieById(string movieId)
        {
            var filterBuilder = Builders<Movie>.Filter;
            var filter = filterBuilder.Eq(m => m.Id, movieId);

            return await _context.Movies.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<Movie> InsertMovie(Movie movie)
        {
            await _context.Movies.InsertOneAsync(movie);
            return movie;
        }

        public async Task<Movie> UpdateMovie(Movie movie)
        {
            var filterBuilder = Builders<Movie>.Filter;
            var filter = filterBuilder.Eq(m => m.Id, movie.Id);

            var updateBuilder = Builders<Movie>.Update;
            var update = updateBuilder.Set(m => m.Title, movie.Title)
                .Set(m => m.Year, movie.Year)
                .Set(m => m.Rating, movie.Rating)
                .Set(m => m.Length, movie.Length)
                .Set(m => m.Genre, movie.Genre)
                .Set(m => m.ReleaseDate, movie.ReleaseDate);

            var options = new FindOneAndUpdateOptions<Movie>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _context.Movies.FindOneAndUpdateAsync(filter, update, options);
        }

        public async Task<Movie> DeleteMovie(string movieId)
        {
            var filterBuilder = Builders<Movie>.Filter;
            var filter = filterBuilder.Eq(m => m.Id, movieId);

            return await _context.Movies.FindOneAndDeleteAsync(filter);
        }

        public async Task<Movie> InsertDirector(string movieId, Person person)
        {
            person.Id = ObjectId.GenerateNewId().ToString();

            var filterBuilder = Builders<Movie>.Filter;
            var filter = filterBuilder.Eq(m => m.Id, movieId);

            var updateBuilder = Builders<Movie>.Update;
            var update = updateBuilder.AddToSet(m => m.Directors, person);

            var options = new FindOneAndUpdateOptions<Movie>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _context.Movies.FindOneAndUpdateAsync(filter, update, options);
        }

        public async Task<Movie> DeleteDirector(string movieId, string personId)
        {
            var filterBuilder = Builders<Movie>.Filter;
            var filter = filterBuilder.Eq(m => m.Id, movieId);

            var updateBuilder = Builders<Movie>.Update;
            var update = updateBuilder.PullFilter(m => m.Directors, p => p.Id == personId);

            var options = new FindOneAndUpdateOptions<Movie>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _context.Movies.FindOneAndUpdateAsync(filter, update, options);
        }

        public async Task<Movie> InsertWriter(string movieId, Person person)
        {
            person.Id = ObjectId.GenerateNewId().ToString();

            var filterBuilder = Builders<Movie>.Filter;
            var filter = filterBuilder.Eq(m => m.Id, movieId);

            var updateBuilder = Builders<Movie>.Update;
            var update = updateBuilder.AddToSet(m => m.Writers, person);

            var options = new FindOneAndUpdateOptions<Movie>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _context.Movies.FindOneAndUpdateAsync(filter, update, options);
        }

        public async Task<Movie> DeleteWriter(string movieId, string personId)
        {
            var filterBuilder = Builders<Movie>.Filter;
            var filter = filterBuilder.Eq(m => m.Id, movieId);

            var updateBuilder = Builders<Movie>.Update;
            var update = updateBuilder.PullFilter(m => m.Writers, p => p.Id == personId);

            var options = new FindOneAndUpdateOptions<Movie>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _context.Movies.FindOneAndUpdateAsync(filter, update, options);
        }

        public async Task<Movie> InsertCastMember(string movieId, Person person)
        {
            person.Id = ObjectId.GenerateNewId().ToString();

            var filterBuilder = Builders<Movie>.Filter;
            var filter = filterBuilder.Eq(m => m.Id, movieId);

            var updateBuilder = Builders<Movie>.Update;
            var update = updateBuilder.AddToSet(m => m.Cast, person);

            var options = new FindOneAndUpdateOptions<Movie>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _context.Movies.FindOneAndUpdateAsync(filter, update, options);
        }

        public async Task<Movie> DeleteCastMember(string movieId, string personId)
        {
            var filterBuilder = Builders<Movie>.Filter;
            var filter = filterBuilder.Eq(m => m.Id, movieId);

            var updateBuilder = Builders<Movie>.Update;
            var update = updateBuilder.PullFilter(m => m.Cast, p => p.Id == personId);

            var options = new FindOneAndUpdateOptions<Movie>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _context.Movies.FindOneAndUpdateAsync(filter, update, options);
        }
    }
}
