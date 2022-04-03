using MediatR;

namespace Estudos.Viagem.Application.UseCase.ObterClientes
{
    public interface IObterClientes : IRequestHandler<ObterClientesInput, ObterClientesOutput>
    {
    }
}