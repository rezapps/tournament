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

        public TourneyRepository(TournamentContext context)
        {
            _context = context;
        }

        public async Task<List<Tourney>> GetAllAsync()
        {
            return await _context.Tourney.ToListAsync();
        }

        public async Task<Tourney> GetAsync(int id)
        {
            return await _context.Tourney.FindAsync(id);
        }

        public async Task<bool> AnyAsync(int id)
        {
            return await _context.Tourney.AnyAsync(g => g.Id == id);
        }

        public void Add(Tourney tourney)
        {
            if (tourney == null)
            {
                throw new ArgumentNullException(nameof(tourney));
            }

            _context.Tourney.Add(tourney);
        }

        public async Task UpdateAsync(Tourney tourney)
        {
            _context.Entry(tourney).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Tourney tourney)
        {
            _context.Tourney.Remove(tourney);
            await _context.SaveChangesAsync();
        }
    }
}
