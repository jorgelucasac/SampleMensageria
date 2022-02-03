using Estudos.Viagem.Application.Services.Messages;
using Estudos.Viagem.Infrastructure.RabbitMq.Services;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estudos.Viagem.Infrastructure.RabbitMq.Extensions;

public static class RabbitMqExtension
{
    public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddMassTransit(bus =>
        {
            bus.UsingRabbitMq((ctx, busConfigurator) =>
            {
                busConfigurator.Host(configuration.GetConnectionString("RabbitMq"));
            });
        });

        services.RegisterServices();
        return services;
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IEventService, EventService>();
        return services;
    }
}