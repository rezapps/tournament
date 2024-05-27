using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Data.Data;

namespace Tournament.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        // Properties
        private readonly TournamentContext _context;

        // Constructor
        public GameRepository(TournamentContext tournamentContext)
        {
            _context = tournamentContext;
        }

        // Check if game exists
        public async Task<bool> AnyAsync(int gameId)
        {
            return await _context.Game.AnyAsync(g => g.Id == gameId);
        }

        // Get all games
        public async Task<List<Game>> GetAllAsync()
        {
            return await _context.Game.ToListAsync();
        }

        // Get game by id
        public async Task<Game> GetAsync(int gameId)
        {
            return await _context.Game
                .FindAsync(gameId)
                ?? throw new KeyNotFoundException($"Game with ID {gameId} not found.");
        }

        // Add game
        public void Add(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            _context.Game.Add(game);
        }

        // Remove game
        public async void RemoveAsync(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
        }

        // Update game
        public async void UpdateAsync(Game game)
        {
            if (game == null)
            {
                throw new ArgumentNullException(nameof(game));
            }

            _context.Game.Update(game);
            await _context.SaveChangesAsync();
        }
    }
}
