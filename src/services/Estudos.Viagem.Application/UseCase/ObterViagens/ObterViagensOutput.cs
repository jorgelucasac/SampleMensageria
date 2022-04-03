using Estudos.Viagem.Core.Responses;
using Estudos.Viagem.Domain.Entities;

namespace Estudos.Viagem.Application.UseCase.ObterViagens
{
    public class ObterViagensOutput : OutputResponse<IList<PacoteViagem>>
    {
        public ObterViagensOutput(IList<PacoteViagem> viagens)
        {
            Data = viagens;
        }

        public ObterViagensOutput(string message, string error)
        {
            Message = message;
            AddErro(error);
        }
    }
}
