using MediatR;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;

namespace Questao5.Domain.Events
{
    public abstract class Event : Message, INotification
    {
        public DateTime Timestamp { get; private set; }

        protected Event()
        {
            Timestamp = DateTime.Now;
        }
    }
}
