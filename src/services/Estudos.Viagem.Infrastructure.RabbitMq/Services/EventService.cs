using Estudos.Viagem.Messages.Events;
using Estudos.Viagem.Messages.Services;
using MassTransit;

namespace Estudos.Viagem.Infrastructure.RabbitMq.Services;

public class EventService : IEventService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task PublishAsync<T>(T @event) where T : Event
    {
        await _publishEndpoint.Publish(@event);
    }
}