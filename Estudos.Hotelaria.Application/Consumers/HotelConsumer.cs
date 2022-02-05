using Estudos.Viagem.Messages.Events;
using MassTransit;
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
        //await Task.Delay(TimeSpan.FromSeconds(7));
        _logger.LogInformation($"msg recebida: tipo: {context.Message.MessageType}, id: {context.Message.CorrelationalId}");
        //throw new Exception("asdasdsa");
    }
}