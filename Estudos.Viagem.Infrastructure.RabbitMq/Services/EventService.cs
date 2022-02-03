using Estudos.Viagem.Application.Services.Messages;
using MassTransit;
using Event = Estudos.Viagem.Messages.Events.Event;

namespace Estudos.Viagem.Infrastructure.RabbitMq.Services;

public class EventService : IEventService
{
    private readonly IPublishEndpoint _publishEndpoint;

    public EventService(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Publish(Event @event)
    {
        await _publishEndpoint.Publish(@event);
    }
}