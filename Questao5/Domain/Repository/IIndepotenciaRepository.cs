using Questao5.Domain.Entities;

namespace Questao5.Domain.Repository
{
    public interface IIndepotenciaRepository : IRepository<Indepotencia>
    {
        Task<Indepotencia> ObterPorChave(Guid chave);

        void Adicionar(Indepotencia indepotencia);

        void Atualizar(Indepotencia indepotencia);

    }
}
