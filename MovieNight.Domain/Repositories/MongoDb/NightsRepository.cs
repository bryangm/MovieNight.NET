using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MovieNight.Domain.Entities;
using MovieNight.Domain.Interfaces;

namespace MovieNight.Domain.Repositories.MongoDb
{
    class NightsRepository : INightsRepository
    {
        private readonly MongoDbContext _context;

        public NightsRepository(MongoDbContext context)
        {
            _context = context;
        }

        public async Task<List<Night>> GetNights()
        {
            return await _context.Nights.Find(new BsonDocument()).ToListAsync();
        }

        public async Task<Night> GetNightById(string id)
        {
            var filterBuilder = Builders<Night>.Filter;
            var filter = filterBuilder.Eq(n => n.Id, id);

            return await _context.Nights.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<Night> InsertNight(Night night)
        {
            await _context.Nights.InsertOneAsync(night);
            return night;
        }

        public async Task<Night> UpdateNight(Night night)
        {
            var filterBuilder = Builders<Night>.Filter;
            var filter = filterBuilder.Eq(n => n.Id, night.Id);

            var updateBuilder = Builders<Night>.Update;
            var update = updateBuilder.Set(n => n.ViewBy, night.ViewBy);

            var options = new FindOneAndUpdateOptions<Night>
            {
                ReturnDocument = ReturnDocument.After
            };

            return await _context.Nights.FindOneAndUpdateAsync(filter, update, options);
        }

        public async Task<Night> DeleteNight(string id)
        {
            var filterBuilder = Builders<Night>.Filter;
            var filter = filterBuilder.Eq(n => n.Id, id);

            return await _context.Nights.FindOneAndDeleteAsync(filter);
        }

    }
}
