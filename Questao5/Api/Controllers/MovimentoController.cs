using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Api.Services;
using Questao5.Api.ViewModels.Movimentos;
using Questao5.Api.ViewModels.Movimentos.Adapters;
using Questao5.Domain.Events;
using Questao5.Domain.Repository;

namespace Questao5.Api.Controllers
{
    [ApiController]
    [Route("movimentos")]
    [Produces("application/json")]
    public class MovimentoController : MainController
    {
        private readonly IMovimentoService _movimentoService;

        public MovimentoController(IMediator mediator,
                                  IUnitOfWork unitOfWork,
                                  INotificationHandler<DomainNotificationEvent> notifications,
                                  IMovimentoService movimentoService) : base(mediator, unitOfWork, notifications)
        {
            _movimentoService = movimentoService;
        }

        [Route("movimentar-conta-corrente")]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> MovimentarContaCorrenteAsync([FromBody] MovimentoViewModel viewModel)
        {
            var movimentoId = await _movimentoService.MovimentarContaCorrenteAsync(viewModel.Map());

            if (await CommitAsync())
                return Response(movimentoId);

            return BadRequestResponse();
        }
    }
}
