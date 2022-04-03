using Estudos.Viagem.Application.UseCase.AtualizarViagemComHotel;
using Estudos.Viagem.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Estudos.Viagem.Application.Consumers
{
    public class AtualizarHotelViagemSucessoConsumer : IConsumer<HotelReservadoEvent>
    {
        private readonly ILogger<AtualizarHotelViagemSucessoConsumer> _logger;
        private readonly IMediator _mediator;

        public AtualizarHotelViagemSucessoConsumer(ILogger<AtualizarHotelViagemSucessoConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<HotelReservadoEvent> context)
        {
            var request = new AtualizarViagemComHotelInput(
                context.Message.ViagemId,
                context.Message.HotelId,
                context.Message.NomeHotel,
                context.Message.ValorDiaria
            );

            var output = await _mediator.Send(request);
            if (output.Success)
                _logger.LogInformation(output.Message);
            else
                _logger.LogError(output.Message, output.Errors);
        }
    }
}