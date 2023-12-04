using MediatR;
using Questao5.Domain.Events;

namespace Questao5.Domain.Handlers
{
    public class DomainNotificationEventHandler : INotificationHandler<DomainNotificationEvent>
    {
        private List<DomainNotificationEvent> _notifications;

        public DomainNotificationEventHandler()
        {
            _notifications ??= new List<DomainNotificationEvent>();
        }

        public Task Handle(DomainNotificationEvent notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public List<DomainNotificationEvent> GetNotifications(DomainNotificationType? type = null)
        {
            return _notifications.Where(x => type is null || x.Type == type).ToList();
        }

        public virtual List<DomainNotificationEvent> GetErrors()
        {
            return GetNotifications(DomainNotificationType.Error);
        }

        public virtual List<DomainNotificationEvent> GetForbiddens()
        {
            return GetNotifications(DomainNotificationType.Forbidden);
        }

        public virtual List<DomainNotificationEvent> GetInformations()
        {
            return GetNotifications(DomainNotificationType.Information);
        }

        public bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public bool HasError()
        {
            return GetErrors().Any();
        }

        public bool HasForbidden()
        {
            return GetForbiddens().Any();
        }

        public bool HasInformation()
        {
            return GetInformations().Any();
        }

        public void ClearNotifications()
        {
            _notifications = new List<DomainNotificationEvent>();
        }
    }
}
