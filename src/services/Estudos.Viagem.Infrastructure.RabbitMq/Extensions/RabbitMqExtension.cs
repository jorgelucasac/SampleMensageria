using Estudos.Viagem.Application.Services.Messages;
using Estudos.Viagem.Application.Consumers;
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
            bus.SetKebabCaseEndpointNameFormatter();
            bus.UsingRabbitMq((ctx, busConfigurator) =>
            {
                busConfigurator.Host(configuration.GetConnectionString("RabbitMq"));
                busConfigurator.ConfigureEndpoints(ctx);
                busConfigurator.PrefetchCount = 1;
            });
            bus.AddConsumers(typeof(AtualizarHotelViagemSucessoConsumer).Assembly);
        });
        services.AddMassTransitHostedService(true);

        services.RegisterServices();
        return services;
    }

    private static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IEventService, EventService>();
        return services;
    }
}