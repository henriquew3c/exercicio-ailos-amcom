using Questao5.Domain.Enumerators;
using Questao5.Domain.Validations;

namespace Questao5.Domain.Entities
{
    public partial class Movimento
    {
        public static class Factory
        {
            public static Movimento Create(
            Guid identificacaoMovimento,
            Guid contaCorrenteId,
            string tipoMovimento,
            double valor)
            {
                var movimento = new Movimento(identificacaoMovimento, contaCorrenteId, tipoMovimento, valor);

                movimento.Validate(movimento, new MovimentoValidation(), options => options.IncludeRuleSets(MovimentoValidation.AdicionarRole));

                return movimento;
            }
        }
    }

    public partial class Movimento : Entity
    {
        public Movimento(
            Guid identificacaoMovimento,
            Guid contaCorrenteId,
            string tipoMovimento,
            double valor)
        {
            ContaCorrenteId = contaCorrenteId;
            DataMovimento = DateTime.Now;
            TipoMovimento = tipoMovimento;
            Valor = valor;
            Id = identificacaoMovimento;
        }

        public Movimento()
        {

        }

        public Guid ContaCorrenteId { get; private set; }

        public DateTime DataMovimento { get; private set; }

        public string TipoMovimento { get; private set; }

        public double Valor { get; private set; }
    }
}
