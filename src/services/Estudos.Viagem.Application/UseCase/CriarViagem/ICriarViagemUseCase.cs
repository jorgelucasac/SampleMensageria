using MediatR;

namespace Estudos.Viagem.Application.UseCase.CriarViagem;

public interface ICriarViagemUseCase : IRequestHandler<CriarViagemInput, CriarViagemOutput>
{ }