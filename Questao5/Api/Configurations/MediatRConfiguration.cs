using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Questao5.Api.Configurations
{
    public static class MediatRConfiguration
    {
        public static void AddMediatRConfiguration(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}
