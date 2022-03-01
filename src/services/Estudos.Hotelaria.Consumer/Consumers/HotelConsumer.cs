using Estudos.Hotelaria.Application.Repositories;
using Estudos.Viagem.Messages.Events;
using Estudos.Viagem.Messages.Services;
using MassTransit;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Estudos.Hotelaria.Consumer.Consumers;

public class HotelConsumer : IConsumer<ViagemCriadaEvent>
{
    private readonly ILogger<HotelConsumer> _logger;
    private readonly IHotelRepository _hotelRepository;
    private readonly IEventService _eventService;

    public HotelConsumer(ILogger<HotelConsumer> logger, IHotelRepository hotelRepository, IEventService eventService)
    {
        _logger = logger;
        _hotelRepository = hotelRepository;
        _eventService = eventService;
    }

    public async Task Consume(ConsumeContext<ViagemCriadaEvent> context)
    {
        var viagem = context.Message;
        try
        {
            var hotel = await _hotelRepository.GetById(viagem.HospedagemId);
            if (hotel == null)
            {
                _logger.LogWarning($"O hotel Id {viagem.HospedagemId} não foi encontrado");
                var hotelReservaFalhou = new HotelReservaFalhou(viagem.ViagemId, new List<string> { "O hotel não foi encontrado" });
                await _eventService.PublishAsync(hotelReservaFalhou);
                return;
            }

            var result = hotel.AdicionarReserva();
            if (!result)
            {
                var hotelReservaFalhou = new HotelReservaFalhou(viagem.ViagemId, hotel.Validate().Errors.Select(e => e.ErrorMessage).ToList());
                await _eventService.PublishAsync(hotelReservaFalhou);
                return;
            }

            await _hotelRepository.Save(hotel);

            var hotelReservadorEvent = new HotelReservadoEvent(viagem.ViagemId, hotel.ValorDiaria);
            await _eventService.PublishAsync(hotelReservadorEvent);
        }
        catch (Exception ex)
        {
            _logger.LogError($"Ocorreu um erro ao reservar o hotel {viagem.HospedagemId}", ex);
            var hotelReservaFalhou = new HotelReservaFalhou(viagem.ViagemId, new List<string> { "Ocorreu um erro ao reservar o hotel" }, true);
            await _eventService.PublishAsync(hotelReservaFalhou);
        }
    }
}