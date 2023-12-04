using Questao5.Infrastructure.IoC;

namespace Questao5.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            BootStrapper.RegisterServices(services);
        }
    }
}
