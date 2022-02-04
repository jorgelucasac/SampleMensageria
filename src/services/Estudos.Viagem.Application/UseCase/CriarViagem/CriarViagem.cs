using Estudos.Viagem.Application.Services.Messages;

namespace Estudos.Viagem.Application.UseCase.CriarViagem;

public class CriarViagem : ICriarViagemUseCase
{
    private readonly IEventService _eventService;

    public CriarViagem(IEventService eventService)
    {
        _eventService = eventService;
    }

    public async Task<CriarViagemOutput> Handle(CriarViagemInput request, CancellationToken cancellationToken)
    {
        await _eventService.PublishAsync(request.ToEvent());

        return OutputSucesso();
    }

    private CriarViagemOutput OutputSucesso()
    {
        var output = new CriarViagemOutput();
        output.AddMessage("Viagem criada com sucesso");
        return output;
    }
}