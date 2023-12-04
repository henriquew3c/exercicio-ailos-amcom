using MediatR;
using Questao5.Api.DTO;
using Questao5.Domain.Exceptions;
using Questao5.Domain.Repository;
using Questao5.Resources;

namespace Questao5.Api.Services
{
    public class ContaCorrenteService : BaseService, IContaCorrenteService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMovimentoRepository _movimentoRepository;

        public ContaCorrenteService(IMediator mediator,
            IMovimentoRepository movimentoRepository,
            IContaCorrenteRepository contaCorrenteRepository) : base(mediator)
        {
            _movimentoRepository = movimentoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<SaldoContaCorrenteResponse> ObterSaldoContaCorrenteAsync(Guid identificacaoContaCorrente)
        {
            var contaCorrente = await _contaCorrenteRepository.ObterPorId(identificacaoContaCorrente);

            if (contaCorrente == null)
                throw new DomainException(MensagemResource.INVALID_ACCOUNT_FOR_BALANCE);

            if (!contaCorrente.Ativo)
                throw new DomainException(MensagemResource.INACTIVE_ACCOUNT_FOR_BALANCE);

            var saldo = await ObterSaldoContaAPartirDasMovimentacoes(identificacaoContaCorrente);

            return new SaldoContaCorrenteResponse(contaCorrente.Id, contaCorrente.Nome, saldo, DateTime.Now);
        }

        private async Task<double> ObterSaldoContaAPartirDasMovimentacoes(Guid identificacaoContaCorrente)
        {
            var movimentacoes = await _movimentoRepository.ObterMovimentacoesContaCorrente(identificacaoContaCorrente);

            double saldo = 0;

            movimentacoes.ToList().ForEach(movimento =>
            {
                if (movimento.TipoMovimento.Equals("C"))
                    saldo += movimento.Valor;

                if (movimento.TipoMovimento.Equals("D"))
                    saldo -= movimento.Valor;
            });

            return saldo;
        }
    }
}
    