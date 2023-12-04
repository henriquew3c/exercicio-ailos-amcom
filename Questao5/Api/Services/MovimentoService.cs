using MediatR;
using Questao5.Domain.Entities;
using Questao5.Domain.Exceptions;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.Data.Repository;
using Questao5.Resources;

namespace Questao5.Api.Services
{
    public class MovimentoService : BaseService, IMovimentoService
    {
        private readonly IContaCorrenteRepository _contaCorrenteRepository;
        private readonly IMovimentoRepository _movimentoRepository;

        public MovimentoService(IMediator mediator,
            IMovimentoRepository movimentoRepository,
            IContaCorrenteRepository contaCorrenteRepository) : base(mediator)
        {
            _movimentoRepository = movimentoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<Guid?> MovimentarContaCorrenteAsync(Movimento movimento)
        {
            if (IsInvalid(movimento))
                return null;

            var contaCorrente = await _contaCorrenteRepository.ObterPorId(movimento.ContaCorrenteId);

            if (contaCorrente == null)
                throw new DomainException(MensagemResource.INVALID_ACCOUNT);

            if(!contaCorrente.Ativo)
                throw new DomainException(MensagemResource.INACTIVE_ACCOUNT);

            _movimentoRepository.Adicionar(movimento);

            return movimento.Id;
        }
    }
}
    