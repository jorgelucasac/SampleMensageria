using Microsoft.Extensions.DependencyInjection;

namespace Estudos.Hotelaria.Consumer.Extensions
{
    public static class WorkerExtension
    {
        public static IServiceCollection AddWorker(this IServiceCollection services)
        {
            services.AddHostedService<Worker>();
            return services;
        }
    }
}
