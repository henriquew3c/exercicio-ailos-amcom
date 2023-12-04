using FluentValidation.Internal;
using FluentValidation;
using MediatR;
using Questao5.Domain.Entities;
using FluentValidation.Results;
using Questao5.Domain.Events;

namespace Questao5.Api.Services
{
    public class BaseService
    {
        private readonly IMediator _mediator;

        protected BaseService(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected void RaiseError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _mediator.Publish(new DomainNotificationEvent(DomainNotificationType.Error, error.PropertyName, error.ErrorMessage));
        }

        protected void RaiseError(string message)
        {
            _mediator.Publish(new DomainNotificationEvent(DomainNotificationType.Error, GetType().Name, message));
        }

        protected void RaiseInformation(string message)
        {
            _mediator.Publish(new DomainNotificationEvent(DomainNotificationType.Information, GetType().Name, message));
        }

        protected bool IsInvalid<T>(T entity, AbstractValidator<T> validator, Action<ValidationStrategy<T>> options) where T : Entity
        {
            entity.Validate(entity, validator, options);

            if (entity.IsInvalid)
                RaiseError(entity.ValidationResult);

            return entity.IsInvalid;
        }

        protected bool IsInvalid<T>(T entity, AbstractValidator<T> validator, Action<ValidationStrategy<T>> options, bool ignoreRaise, out ValidationResult result) where T : Entity
        {
            entity.Validate(entity, validator, options);
            result = entity.ValidationResult;

            if (!ignoreRaise && entity.IsInvalid)
                RaiseError(entity.ValidationResult);

            return entity.IsInvalid;
        }

        protected bool IsInvalid<T>(List<T> entities, AbstractValidator<T> validator, Action<ValidationStrategy<T>> options) where T : Entity
        {
            var isInvalid = false;

            foreach (var entity in entities)
            {
                isInvalid = IsInvalid(entity, validator, options);

                if (isInvalid)
                    break;
            }

            return isInvalid;
        }

        protected bool IsInvalid(Entity entity)
        {
            if (entity.IsInvalid)
                RaiseError(entity.ValidationResult);

            return entity.IsInvalid;
        }

        protected bool IsInvalid<T>(List<T> entities) where T : Entity
        {
            var isInvalid = false;

            foreach (var entity in entities)
            {
                if (entity.IsInvalid)
                {
                    isInvalid = true;
                    RaiseError(entity.ValidationResult);
                }
            }

            return isInvalid;
        }
    }
}
