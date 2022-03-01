using Estudos.Viagem.Messages.Events;

namespace Estudos.Viagem.Messages.Services;

public interface IEventService
{
    Task PublishAsync<T>(T @event) where T : Event;
}