using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tournament.Core.Repositories
{
    public interface IUnitOfWork
    {
        IGameRepository Game { get; }
        ITourneyRepository Tourney { get; }

        Task<int> SaveChangesAsync();
        
    }
}
