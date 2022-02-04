using Estudos.Viagem.Messages.Events;

namespace Estudos.Viagem.Application.Services.Messages;

public interface IEventService
{
    Task PublishAsync<T>(T @event) where T : Event;
}