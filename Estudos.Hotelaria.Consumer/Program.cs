using MassTransit;
using MassTransit.Definition;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using System.Reflection;

namespace Estudos.Hotelaria.Consumer;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[]? args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            .Enrich.FromLogContext()
            .WriteTo.Console()
            .CreateLogger();

        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.AddJsonFile("appsettings.json", true);
                config.AddEnvironmentVariables();

                if (args is not null)
                    config.AddCommandLine(args);
            })
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddSerilog(dispose: true);
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddMassTransit(x =>
                {
                    services.TryAddSingleton(KebabCaseEndpointNameFormatter.Instance);

                    var entryAssembly = Assembly.GetEntryAssembly();
                    x.AddConsumers(entryAssembly);

                    x.UsingRabbitMq((context, cfg) =>
                    {
                        cfg.Host(hostContext.Configuration.GetConnectionString("RabbitMq"));
                        cfg.ConfigureEndpoints(context);
                        cfg.PrefetchCount = 1;
                    });
                });
                services.AddMassTransitHostedService(true);
                services.AddHostedService<Worker>();
            });
    }
}