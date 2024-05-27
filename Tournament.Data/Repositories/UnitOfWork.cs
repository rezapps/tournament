using System.Threading.Tasks;
using Tournament.Core.Repositories;
using Tournament.Data.Data;

namespace Tournament.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly TournamentContext _context;
        private IGameRepository _gameRepository;
        private ITourneyRepository _tourneyRepository;

        public UnitOfWork(TournamentContext context)
        {
            _context = context;
        }

        public IGameRepository Game => _gameRepository ??= new GameRepository(_context);
        public ITourneyRepository Tourney => _tourneyRepository ??= new TourneyRepository(_context);

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
