using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Api.Models;
using Questao5.Domain.Events;
using Questao5.Domain.Handlers;
using Questao5.Domain.Repository;

namespace Questao5.Api.Controllers
{
    public abstract class MainController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMediator _mediator;
        private readonly DomainNotificationEventHandler _notifications;

        public MainController(IMediator mediator,
                              IUnitOfWork unitOfWork,
                              INotificationHandler<DomainNotificationEvent> notifications)
        {
            _notifications = (DomainNotificationEventHandler)notifications;
            _mediator = mediator;
            _unitOfWork = unitOfWork;
        }


        protected CreatedResult CreatedResponse()
        {
            return Created(string.Empty, null);
        }

        protected BadRequestObjectResult BadRequestResponse()
        {
            return BadRequest(GetNotifications());
        }

        protected IEnumerable<string> GetNotifications()
        {
            return _notifications.GetNotifications().Select(n => n.Value).ToList();
        }

        protected async Task<bool> CommitAsync()
        {
            if (!IsValidOperation())
                return false;

            return await _unitOfWork.CommitAsync();
        }

        protected bool IsValidOperation()
        {
            return !_notifications.HasError() &&
                   !_notifications.HasForbidden();
        }

        protected void RaiseErrorModel()
        {
            var erros = ModelState.Values.SelectMany(x => x.Errors);

            foreach (var erro in erros)
                _mediator.Publish(new DomainNotificationEvent(DomainNotificationType.Error, GetType().Name, erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message));
        }

        protected void RaiseError(List<string> error)
        {
            error?.ForEach(error => RaiseError(error));
        }

        protected void RaiseError(string error)
        {
            _mediator.Publish(new DomainNotificationEvent(DomainNotificationType.Error, GetType().Name, error));
        }

        protected void RaiseForbidden(string error)
        {
            _mediator.Publish(new DomainNotificationEvent(DomainNotificationType.Forbidden, GetType().Name, error));
        }

        protected void RaiseInformation(string message)
        {
            _mediator.Publish(new DomainNotificationEvent(DomainNotificationType.Information, GetType().Name, message));
        }

        protected virtual bool ModelStateIsValid()
        {
            if (ModelState.IsValid)
                return true;

            RaiseErrorModel();
            return false;
        }

        protected new IActionResult Response(object result = null)
        {
            var success = IsValidOperation();

            if (success)
            {
                return Ok(new ResponseResult
                {
                    Success = success,
                    Notifications = _notifications.GetNotifications().Select(n => n.Value).ToList(),
                    Data = success ? result : null
                });
            }

            if (_notifications.HasForbidden())
            {
                ObjectResult forbiddenResult = StatusCode(StatusCodes.Status403Forbidden, new ForbiddenResponseResult
                {
                    Success = success,
                    Data = result,
                    Notifications = _notifications.GetNotifications().Select(n => n.Value).ToList()
                });

                return forbiddenResult;
            }

            if (_notifications.HasError())
            {
                return BadRequest(new BadResponseResult
                {
                    Success = success,
                    Data = result,
                    Notifications = _notifications.GetNotifications().Select(n => n.Value).ToList(),
                });
            }

            throw new NotImplementedException();
        }
    }
}
