using Questao5.Domain.Entities;

namespace Questao5.Api.Services
{
    public interface IMovimentoService
    {
        Task<Guid?> MovimentarContaCorrenteAsync(Movimento movimento);
    }
}
    