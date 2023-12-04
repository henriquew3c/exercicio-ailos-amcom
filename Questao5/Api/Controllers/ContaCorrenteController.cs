using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Api.Services;
using Questao5.Domain.Events;
using Questao5.Domain.Repository;

namespace Questao5.Api.Controllers
{
    [ApiController]
    [Route("conta-corrente")]
    [Produces("application/json")]
    public class ContaCorrenteController : MainController
    {
        private readonly IContaCorrenteService _contaCorrenteService;

        public ContaCorrenteController(IMediator mediator,
                                  IUnitOfWork unitOfWork,
                                  INotificationHandler<DomainNotificationEvent> notifications,
                                  IContaCorrenteService contaCorrenteService) : base(mediator, unitOfWork, notifications)
        {
            _contaCorrenteService = contaCorrenteService;
        }

        [Route("obter-saldo")]
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> ObterSaldoContaCorrenteAsync(Guid identificacaoContaCorrente)
        {
            try
            {
                var saldoContaCorrenteResponse = await _contaCorrenteService.ObterSaldoContaCorrenteAsync(identificacaoContaCorrente);
                return Response(saldoContaCorrenteResponse);
            }
            catch (Exception)
            {
                return BadRequestResponse();
            }
        }
    }
}
