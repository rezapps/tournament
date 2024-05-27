using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tournament.Core.Repositories;
using Tournament.Data.Data;
using Tournament.Core.Entities;


namespace Tournament.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TournamentContext _context;
        private readonly IGameRepository _game;
        private readonly ITourneyRepository _tourney;

        public UnitOfWork(TournamentContext context, IGameRepository game, ITourneyRepository tourney)
        {
            _context = context;
            _game = game;
            _tourney = tourney;
        }
        public IGameRepository Game => _game;
        public ITourneyRepository Tourney => _tourney;

        // expression body
        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    }
}
