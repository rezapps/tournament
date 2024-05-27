using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface ITourneyRepository
    {
        Task<List<Tourney>> GetAllAsync();
        Task<Tourney> GetAsync(int id);
        Task<bool> AnyAsync(int id);
        void Add(Tourney tourney);
        Task UpdateAsync(Tourney tourney);
        Task RemoveAsync(Tourney tourney);
    }
}
