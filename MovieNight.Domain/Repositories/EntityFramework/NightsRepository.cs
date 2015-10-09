using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieNight.Domain.Entities;
using MovieNight.Domain.Interfaces;

namespace MovieNight.Domain.Repositories.EntityFramework
{
    public class NightsRepository : INightsRepository
    {
        public Task<Night> DeleteNight(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Night> GetNightById(string id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Night>> GetNights()
        {
            throw new NotImplementedException();
        }

        public Task<Night> InsertNight(Night night)
        {
            throw new NotImplementedException();
        }

        public Task<Night> UpdateNight(Night night)
        {
            throw new NotImplementedException();
        }
    }
}
