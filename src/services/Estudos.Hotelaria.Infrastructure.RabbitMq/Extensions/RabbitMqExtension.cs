using Estudos.Hotelaria.Application.Consumers;
using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Estudos.Hotelaria.Infrastructure.RabbitMq.Extensions
{
    public static class RabbitMqExtension
    {
        public static IServiceCollection AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMassTransit(x =>
            {
                x.SetKebabCaseEndpointNameFormatter();

                x.AddConsumers(typeof(HotelConsumer).Assembly);

                x.AddDelayedMessageScheduler();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(configuration.GetConnectionString("RabbitMq"));
                    cfg.ConfigureEndpoints(context);
                    cfg.PrefetchCount = 1;
                    cfg.UseDelayedMessageScheduler();
                });
            });
            services.AddMassTransitHostedService(true);
            return services;
        }
    }
}
