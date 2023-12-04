using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.Data;

namespace Questao5.Infrastructure.Data.Repository
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly Context _context;

        public ContaCorrenteRepository(Context context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Dispose()
        {
            _context?.Dispose();
        }

        public async Task<ContaCorrente> ObterPorId(Guid id)
        {
            return await _context.ContaCorrente.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<ICollection<ContaCorrente>> ObterTodas()
        {
            return await _context.ContaCorrente.AsNoTracking().ToListAsync();
        }
    }
}
