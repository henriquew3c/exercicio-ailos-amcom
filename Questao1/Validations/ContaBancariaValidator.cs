using FluentValidation;

namespace Questao1.Validations
{
    public class ContaBancariaValidator : AbstractValidator<ContaBancaria>
    {
        public ContaBancariaValidator()
        {
            RuleFor(customer => customer.NumeroConta)
                .GreaterThan(0)
                .WithMessage("O campo Número é inválido.");

            RuleFor(customer => customer.NomeTitular)
                .NotEmpty()
                .WithMessage("O campo Nome do Titular é inválido.");
        }
    }
}
