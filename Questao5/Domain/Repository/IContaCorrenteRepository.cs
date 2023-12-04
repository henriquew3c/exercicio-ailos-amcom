using Questao5.Domain.Entities;

namespace Questao5.Domain.Repository
{
    public interface IContaCorrenteRepository : IRepository<ContaCorrente>
    {
        Task<ContaCorrente> ObterPorId(Guid id);

        Task<ICollection<ContaCorrente>> ObterTodas();
    }
}
