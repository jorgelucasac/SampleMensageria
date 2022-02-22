using MediatR;

namespace Estudos.Viagem.Application.UseCase.CadastrarCliente
{
    public interface ICadastrarClienteUseCase : IRequestHandler<CadastrarClienteInput, CadastrarClienteOutput>
    {
    }
}