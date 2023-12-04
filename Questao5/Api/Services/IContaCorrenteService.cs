using Questao5.Api.DTO;

namespace Questao5.Api.Services
{
    public interface IContaCorrenteService
    {
        Task<SaldoContaCorrenteResponse> ObterSaldoContaCorrenteAsync(Guid identificacaoContaCorrente);
    }
}
    