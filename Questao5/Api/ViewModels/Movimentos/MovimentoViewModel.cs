using Questao5.Domain.Enumerators;

namespace Questao5.Api.ViewModels.Movimentos
{
    public class MovimentoViewModel
    {
        public Guid IdentificacaoMovimento { get; set; } = Guid.NewGuid();

        public Guid IdentificacaoContaCorrente { get; set; }

        public string TipoMovimento { get; set; }

        public double Valor { get; set; }
    }
}
