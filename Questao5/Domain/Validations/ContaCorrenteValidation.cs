using Castle.Components.DictionaryAdapter;
using FluentValidation;
using Questao5.Domain.Entities;
using Questao5.Resources;

namespace Questao5.Domain.Validations
{
    internal class MovimentoValidation : AbstractValidator<Movimento>
    {
        public const string AdicionarRole = "AdicionarRole";

        public MovimentoValidation()
        {
            RuleSet(AdicionarRole, () => Adicionar());
        }

        private void Adicionar()
        {
            IdentificacaoMovimento();
            IdentificacaoContaCorrente();
            TipoMovimento();
            Valor();

        }

        private void IdentificacaoMovimento()
        {
            RuleFor(c => c.ContaCorrenteId)
                .NotEmpty()
                .NotNull()
                .WithMessage(MensagemResource.INVALID_MOVIMENT); ;
        }

        private void IdentificacaoContaCorrente()
        {
            RuleFor(c => c.ContaCorrenteId)
                .NotEmpty()
                .NotNull()
                .WithMessage(MensagemResource.INVALID_ACCOUNT); ;
        }

        private void TipoMovimento()
        {
            RuleFor(c => c.TipoMovimento)
                .Must(TiposMovimentosValidos)
                .WithMessage(MensagemResource.INVALID_TYPE);
        }

        private void Valor()
        {
            RuleFor(c => c.Valor)
                .NotNull()
                .GreaterThan(0)
                .WithMessage(MensagemResource.INVALID_VALUE);
        }

        private static bool TiposMovimentosValidos(string arg)
        {
            return arg.Equals("C") || arg.Equals("D");
        }
    }
}
