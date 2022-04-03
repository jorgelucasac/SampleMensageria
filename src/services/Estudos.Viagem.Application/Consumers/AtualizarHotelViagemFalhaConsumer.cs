using Estudos.Viagem.Application.UseCase.AtualizarViagemComHotel;
using Estudos.Viagem.Messages.Events;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Estudos.Viagem.Application.Consumers
{
    public class AtualizarHotelViagemFalhaConsumer : IConsumer<HotelReservaFalhou>
    {
        private readonly ILogger<AtualizarHotelViagemFalhaConsumer> _logger;
        private readonly IMediator _mediator;

        public AtualizarHotelViagemFalhaConsumer(ILogger<AtualizarHotelViagemFalhaConsumer> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<HotelReservaFalhou> context)
        {
            var request = new AtualizarViagemComHotelInput(context.Message.CorrelationalId, context.Message.Mensagens);
            var output = await _mediator.Send(request);
            if (output.Success)
                _logger.LogInformation(output.Message);
            else
                _logger.LogError(output.Message, output.Errors);         
        }
    }
}