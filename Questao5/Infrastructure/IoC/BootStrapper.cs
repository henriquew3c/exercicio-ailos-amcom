using MediatR;
using Questao5.Api.Services;
using Questao5.Domain.Events;
using Questao5.Domain.Handlers;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.Data;
using Questao5.Infrastructure.Data.Repository;
using Questao5.Infrastructure.Data.UoW;

namespace Questao5.Infrastructure.IoC
{
    public static class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Events
            services.AddScoped<INotificationHandler<DomainNotificationEvent>, DomainNotificationEventHandler>();

            // Data
            services.AddScoped<Context>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<IMovimentoRepository, MovimentoRepository>();
            services.AddScoped<IIndepotenciaRepository, IndepotenciaRepository>();

            //Services
            services.AddScoped<IMovimentoService, MovimentoService>();

        }
    }
}
