using Estudos.Viagem.Core.Responses;
using FluentValidation.Results;

namespace Estudos.Viagem.Application.UseCase.AtualizarViagemComHotel
{
    public class AtualizarViagemComHotelOutput : OutputResponse<object>
    {
        public AtualizarViagemComHotelOutput()
        {
            Message = "Viagem atualizada com sucesso";
        }

        public AtualizarViagemComHotelOutput(string message, string error = null)
        {
            Message = message;
            AddErro(error ?? message);
        }

        public AtualizarViagemComHotelOutput(string message, IList<ValidationFailure> errors)
        {
            Message = message;
            errors.ToList().ForEach(e => AddErro(e.ErrorMessage, e.PropertyName));
        }
    }
}
