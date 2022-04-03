using MediatR;

namespace Estudos.Hotelaria.Consumer.UseCases.ReservarHotel
{
    internal interface IReservarHotel : IRequestHandler<ReservarHotelInput, ReservarHotelOutput>
    {
    }
}