using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Entities;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.Data;

namespace Questao5.Infrastructure.Data.Repository
{
    public class IndepotenciaRepository : IIndepotenciaRepository
    {
        private readonly Context _context;

        public IndepotenciaRepository(Context context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public void Adicionar(Indepotencia indepotencia)
        {
            _context.Indepotencia.Add(indepotencia);
        }

        public void Atualizar(Indepotencia indepotencia)
        {
            _context.Indepotencia.Update(indepotencia);
        }

        public async Task<Indepotencia> ObterPorChave(Guid chave)
        {
            return await _context.Indepotencia.AsNoTracking().FirstOrDefaultAsync(p => p.Chave.Equals(chave));
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
