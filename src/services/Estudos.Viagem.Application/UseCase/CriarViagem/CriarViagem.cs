using Estudos.Viagem.Application.Repositories;
using Estudos.Viagem.Application.Services.Messages;

namespace Estudos.Viagem.Application.UseCase.CriarViagem;

public class CriarViagem : ICriarViagemUseCase
{
    private readonly IEventService _eventService;
    private readonly IViagemRepository _viagemRepository;
    private readonly IClienteRepository _clienteRepository;

    public CriarViagem(IEventService eventService, IViagemRepository viagemRepository, IClienteRepository clienteRepository)
    {
        _eventService = eventService;
        _viagemRepository = viagemRepository;
        _clienteRepository = clienteRepository;
    }

    public async Task<CriarViagemOutput> Handle(CriarViagemInput request, CancellationToken cancellationToken)
    {
        var cliente = await _clienteRepository.GetById(request.ClienteId);
        if (cliente == null)
            return OutputFalha("Cliente não encontrado");

        var viagem = request.ToViagem();
        await _viagemRepository.Save(viagem);

        if (request.HospedagemId != null && request.HospedagemId != Guid.Empty)
            await _eventService.PublishAsync(request.ToEvent(viagem.Id));

        //TODO: Tratar quando houver o serviço de carro
        //if (request.CarroId != null)
        //await _eventService.PublishAsync(request.ToEvent());
        return OutputSucesso();
    }

    private CriarViagemOutput OutputSucesso()
    {
        var output = new CriarViagemOutput();
        output.AddMessage("Viagem criada com sucesso");
        return output;
    }

    private CriarViagemOutput OutputFalha(string msgErro)
    {
        var output = new CriarViagemOutput();
        output.AddErro(msgErro);
        return output;
    }
}