using Estudos.Viagem.Application.Repositories;
using Estudos.Viagem.Infrastructure.SqlServer.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Estudos.Viagem.Infrastructure.SqlServer.Extensions
{
    public static class RegisterRepositoriesExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<ICarroRepository, CarroRepository>();
            services.AddTransient<IViagemRepository, ViagemRepository>();
        }
    }
}