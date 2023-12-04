using Questao5.Domain.Entities;

namespace Questao5.Domain.Repository
{
    public interface IMovimentoRepository : IRepository<Movimento>
    {
        void Adicionar(Movimento movimento);
        
        Task<ICollection<Movimento>> ObterMovimentacoesContaCorrente(Guid identificacaoContaCorrente);
    }
}
