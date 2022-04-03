using Estudos.Viagem.Core.Responses;
using Estudos.Viagem.Domain.Entities;

namespace Estudos.Viagem.Application.UseCase.ObterClientes
{
    public class ObterClientesOutput : OutputResponse<IList<Cliente>>
    {
        public ObterClientesOutput(IList<Cliente> clientes)
        {
            Data = clientes;
        }

        public ObterClientesOutput(string message, string error)
        {
            Message = message;
            AddErro(error);
        }
    }
}