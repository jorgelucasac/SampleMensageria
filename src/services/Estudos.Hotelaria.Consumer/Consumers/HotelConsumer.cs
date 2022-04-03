using Estudos.Hotelaria.Consumer.UseCases.ReservarHotel;
using Estudos.Viagem.Messages.Events;
using Estudos.Viagem.Messages.Services;
using MassTransit;
using MediatR;

namespace Estudos.Hotelaria.Consumer.Consumers;

public class HotelConsumer : IConsumer<ViagemCriadaEvent>
{
    private readonly IMediator _mediator;
    private readonly IEventService _eventService;

    public HotelConsumer(IMediator mediator, IEventService eventService)
    {
        _mediator = mediator;
        _eventService = eventService;
    }

    public async Task Consume(ConsumeContext<ViagemCriadaEvent> context)
    {
        if (context.Message.HospedagemId == null || context.Message.HospedagemId == Guid.Empty)
            await _eventService.PublishAsync(new HotelReservaFalhou(context.Message.CorrelationalId, "HospdegamId", "Informe o id do hotel"));

        var request = new ReservarHotelInput(context.Message.HospedagemId.Value);
        var output = await _mediator.Send(request);

        if (!output.Success)
            await _eventService.PublishAsync(new HotelReservaFalhou(context.Message.CorrelationalId, output.Errors));
        else
            await _eventService.PublishAsync(new HotelReservadoEvent(context.Message.CorrelationalId, output.Data.Id, output.Data.Nome, output.Data.ValorDiaria));
    }
}