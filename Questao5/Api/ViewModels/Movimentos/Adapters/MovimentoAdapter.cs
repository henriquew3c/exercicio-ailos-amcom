using Questao5.Domain.Entities;

namespace Questao5.Api.ViewModels.Movimentos.Adapters
{
    public static class MovimentoAdapter
    {
        public static Movimento Map(this MovimentoViewModel input)
        {
            return Movimento.Factory.Create(
                input.IdentificacaoMovimento,
                input.IdentificacaoContaCorrente,
                input.TipoMovimento,
                input.Valor);
        }
    }
}
