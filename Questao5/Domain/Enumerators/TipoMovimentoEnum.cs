using System.ComponentModel;

namespace Questao5.Domain.Enumerators
{
    public enum TipoMovimentoEnum
    {
        [Description("CREDITO")]
        C = 1,
        [Description("DEBITO")]
        D = 2
    }
}
