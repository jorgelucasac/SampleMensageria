using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Estudos.Viagem.Application.Extensions;

public static class ApplicationExtension
{
    public static IServiceCollection RegisterApplication(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ApplicationExtension).Assembly);
        return services;
    }
}