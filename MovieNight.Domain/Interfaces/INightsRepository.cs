using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MovieNight.Domain.Entities;

namespace MovieNight.Domain.Interfaces
{
    public interface INightsRepository
    {
        Task<List<Night>> GetNights();
        Task<Night> GetNightById(string id);
        Task<Night> InsertNight(Night night);
        Task<Night> UpdateNight(Night night);
        Task<Night> DeleteNight(string id);
    }
}
