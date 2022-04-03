using Estudos.Hotelaria.Application.Entities;
using Estudos.Viagem.Core.Responses;
using FluentValidation.Results;

namespace Estudos.Hotelaria.Consumer.UseCases.ReservarHotel
{
    public class ReservarHotelOutput : OutputResponse<Hotel>
    {
        public ReservarHotelOutput(Hotel hotel)
        {
            Message = "Hotel reservado com sucesso";
            Data = hotel;
        }

        public ReservarHotelOutput(string message)
        {
            AddErro(message, "Hotel");
        }

        public ReservarHotelOutput(IList<ValidationFailure> errors)
        {
            errors.ToList().ForEach(e => e.PropertyName = "Hotel");
            Errors.AddRange(errors);
        }
    }
}