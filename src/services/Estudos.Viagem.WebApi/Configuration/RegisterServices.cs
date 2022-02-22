using Estudos.Viagem.Application.Extensions;
using Estudos.Viagem.Infrastructure.RabbitMq.Extensions;
using Estudos.Viagem.Infrastructure.SqlServer.Extensions;

namespace Estudos.Viagem.WebApi.Configuration;

public static class RegisterServices
{
    public static IServiceCollection RegisterApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.RegisterApplication();
        services.AddRabbitMq(configuration);
        services.AddRepositories();

        return services;
    }
}