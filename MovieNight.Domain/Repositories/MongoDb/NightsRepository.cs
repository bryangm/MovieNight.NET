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
            return await _context.Nights.Find(x => x.Id == id).SingleOrDefaultAsync();
        }

        public async Task SaveNight(Night night)
        {
            await _context.Nights.InsertOneAsync(night);
        }

        public async Task DeleteNight(string id)
        {
            await _context.Nights.FindOneAndDeleteAsync(x => x.Id == id);
        }

    }
}
