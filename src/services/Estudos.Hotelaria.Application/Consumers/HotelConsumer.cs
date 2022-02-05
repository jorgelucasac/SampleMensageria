using Estudos.Viagem.Messages.Events;
using GreenPipes;
using MassTransit;
using MassTransit.ConsumeConfigurators;
using MassTransit.Definition;
using Microsoft.Extensions.Logging;

namespace Estudos.Hotelaria.Application.Consumers;

public class HotelConsumer : IConsumer<ViagemCriadaEvent>
{
    private readonly ILogger<HotelConsumer> _logger;

    public HotelConsumer(ILogger<HotelConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<ViagemCriadaEvent> context)
    {
        //await Task.Delay(TimeSpan.FromSeconds(2));
        _logger.LogInformation($"\nmsg recebida: tipo: {context.Message.MessageType}, id: {context.Message.CorrelationalId}\n");
        throw new Exception("asdasdsa");
    }
}


public class HotelConsumerDefinition : ConsumerDefinition<HotelConsumer>
{
    public HotelConsumerDefinition()
    {
        Endpoint(x =>
        {
            x.Name = "hotel-queue-consumer";
            x.PrefetchCount = 1;
        });
    }

    protected override void ConfigureConsumer(IReceiveEndpointConfigurator endpointConfigurator, IConsumerConfigurator<HotelConsumer> consumerConfigurator)
    {
        consumerConfigurator.UseMessageRetry(retryConfigurator =>
        {
            retryConfigurator.Incremental(3,
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(5)
            );
        });
        
        //TODO: Revisitar método que não está funcionando adequadamente
        consumerConfigurator.UseDelayedRedelivery(r =>
        {
            r.Intervals(
                TimeSpan.FromSeconds(5),
                TimeSpan.FromSeconds(15),
                TimeSpan.FromSeconds(30)
            );
        });
    }
}