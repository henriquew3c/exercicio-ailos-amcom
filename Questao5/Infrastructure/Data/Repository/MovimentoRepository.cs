using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.Data;

namespace Questao5.Infrastructure.Data.Repository
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly Context _context;

        public MovimentoRepository(Context context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Movimento movimento)
        {
            _context.Movimento.Add(movimento);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }



        public async Task<ICollection<Movimento>> ObterMovimentacoesContaCorrente(Guid identificacaoContaCorrente)
        {
            return await _context.Movimento
                .Where(m => m.ContaCorrenteId.Equals(identificacaoContaCorrente))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
