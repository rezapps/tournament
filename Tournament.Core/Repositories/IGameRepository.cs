using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Core.Entities;

namespace Tournament.Core.Repositories
{
    public interface IGameRepository
    {
        Task<List<Game>> GetAllAsync();
        Task<Game> GetAsync(int id);
        Task<bool> AnyAsync(int id);
        void Add(Game game);
        Task UpdateAsync(Game game);
        Task RemoveAsync(Game game);
    }
}
