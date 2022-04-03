using Estudos.Viagem.Domain.Repositories;
using Estudos.Viagem.Infrastructure.SqlServer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Estudos.Viagem.Infrastructure.SqlServer.Extensions
{
    public static class RegisterRepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IViagemRepository, ViagemRepository>();
        }

        public static void InitDatabase(this IServiceProvider services)
        {
            var scope = services.CreateScope();
            var servicesProvider = scope.ServiceProvider;
            var context = servicesProvider.GetRequiredService<ViagemDataContext>();
            context.Database.EnsureCreated();
        }
    }
}