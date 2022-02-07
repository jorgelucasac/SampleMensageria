using Estudos.Hotelaria.Consumer.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Estudos.Hotelaria.Consumer;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    public static IHostBuilder CreateHostBuilder(string[]? args)
    {
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
                logging.AddSerilog(hostingContext.Configuration);
            })
            .ConfigureServices((hostContext, services) =>
            {
                services.AddRabbitMq(hostContext.Configuration);
            });
    }
}