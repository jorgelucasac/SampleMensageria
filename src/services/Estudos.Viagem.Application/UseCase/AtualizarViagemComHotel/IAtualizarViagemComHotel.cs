using MediatR;

namespace Estudos.Viagem.Application.UseCase.AtualizarViagemComHotel
{
    internal interface IAtualizarViagemComHotel : IRequestHandler<AtualizarViagemComHotelInput, AtualizarViagemComHotelOutput>
    {
    }
}