using Estudos.Viagem.Messages.Events;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Estudos.Hotelaria.Consumer.Consumers;

public class HotelConsumer : IConsumer<ViagemCriadaEvent>
{
    private readonly ILogger<HotelConsumer> _logger;

    public HotelConsumer(ILogger<HotelConsumer> logger)
    {
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<ViagemCriadaEvent> context)
    {
        _logger.LogInformation($"\nmsg recebida: tipo: {context.Message.MessageType}, id: {context.Message.CorrelationalId}\n");
    }
}