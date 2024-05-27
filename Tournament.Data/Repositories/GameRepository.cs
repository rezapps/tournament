using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Data.Data;

namespace Tournament.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly TournamentContext _context;

        public GameRepository(TournamentContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Game.ToListAsync();
        }

        public async Task<Game> GetAsync(int id)
        {
            return await _context.Game.FindAsync(id);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context.Game.AnyAsync(g => g.Id == id);
        }

        public void Add(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            _context.Game.Add(game);
        }

        public async Task UpdateAsync(Game game)
        {
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Game game)
        {
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
        }
    }
}
