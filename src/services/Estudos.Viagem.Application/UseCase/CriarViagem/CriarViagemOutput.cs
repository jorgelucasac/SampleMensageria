using Estudos.Viagem.Core.Responses;
using FluentValidation.Results;

namespace Estudos.Viagem.Application.UseCase.CriarViagem;

public class CriarViagemOutput : OutputResponse<object>
{
    public CriarViagemOutput()
    {
        Message = "Viagem criada com sucesso";
    }

    public CriarViagemOutput(string mensagem, IList<ValidationFailure> erros = null)
    {
        Message = mensagem;
        if (erros != null)
            Errors.AddRange(erros);
        else
            AddErro(mensagem, "ClienteId");
    }
}