using Microsoft.EntityFrameworkCore;
using Tournament.Core.Entities;
using Tournament.Core.Repositories;
using Tournament.Data.Data;

namespace Tournament.Data.Repositories
{
    public class TourneyRepository : ITourneyRepository
    {
        // Properties
        private readonly TournamentContext _context;

        // Constructor
        public TourneyRepository(TournamentContext tournamentContext)
        {
            _context = tournamentContext;
        }

        // Check if Tourney exists
        public async Task<bool> AnyAsync(int tourneyId)
        {
            return await _context.Tourney.AnyAsync(g => g.Id == tourneyId);
        }

        // Get all Tourneys
        public async Task<List<Tourney>> GetAllAsync()
        {
            return await _context.Tourney.ToListAsync();
        }

        // Get Tourney by id
        public async Task<Tourney> GetAsync(int tourneyId)
        {
            return await _context.Tourney
                .FindAsync(tourneyId)
                ?? throw new KeyNotFoundException($"Tourney with ID {tourneyId} not found.");
        }

        // Add Tourney
        public void Add(Tourney Tourney)
        {
            if (Tourney == null)
            {
                throw new ArgumentNullException(nameof(Tourney));
            }

            _context.Tourney.Add(Tourney);
        }

        // Remove Tourney
        public async void RemoveAsync(Tourney Tourney)
        {
            if (Tourney == null)
            {
                throw new ArgumentNullException(nameof(Tourney));
            }

            _context.Tourney.Remove(Tourney);
            await _context.SaveChangesAsync();
        }

        // Update Tourney
        public async void UpdateAsync(Tourney Tourney)
        {
            if (Tourney == null)
            {
                throw new ArgumentNullException(nameof(Tourney));
            }

            _context.Tourney.Update(Tourney);
            await _context.SaveChangesAsync();
        }
    }
}
