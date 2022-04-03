using Estudos.Hotelaria.Application.Repositories;
using Microsoft.Extensions.Logging;

namespace Estudos.Hotelaria.Consumer.UseCases.ReservarHotel
{
    internal class ReservarHotel : IReservarHotel
    {
        private readonly ILogger<ReservarHotel> _logger;
        private readonly IHotelRepository _hotelRepository;

        public ReservarHotel(ILogger<ReservarHotel> logger, IHotelRepository hotelRepository)
        {
            _logger = logger;
            _hotelRepository = hotelRepository;
        }

        public async Task<ReservarHotelOutput> Handle(ReservarHotelInput request, CancellationToken cancellationToken)
        {
            try
            {
                var hotel = await _hotelRepository.GetById(request.HotelId);
                if (hotel == null)
                    return new ReservarHotelOutput("O hotel não foi encontrado");

                var result = hotel.AdicionarReserva();
                if (!result)
                    return new ReservarHotelOutput(hotel.Validate().Errors);

                await _hotelRepository.Save(hotel);
                return new ReservarHotelOutput(hotel);
            }
            catch (Exception ex)
            {
                const string errMsg = "Ocorreu um erro ao reservar o hotel";
                _logger.LogError(errMsg, ex);
                return new ReservarHotelOutput(errMsg);
            }
        }
    }
}