using MediatR;

namespace Estudos.Viagem.Application.UseCase.ObterViagens
{
    internal interface IObterViagens : IRequestHandler<ObterViagensInput, ObterViagensOutput>
    {
    }
}