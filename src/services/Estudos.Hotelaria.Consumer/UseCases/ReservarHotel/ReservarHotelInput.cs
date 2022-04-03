using MediatR;

namespace Estudos.Hotelaria.Consumer.UseCases.ReservarHotel
{
    public class ReservarHotelInput : IRequest<ReservarHotelOutput>
    {
        public ReservarHotelInput(Guid hotelId)
        {
            HotelId = hotelId;
        }

        public Guid HotelId { get; private set; }
    }
}