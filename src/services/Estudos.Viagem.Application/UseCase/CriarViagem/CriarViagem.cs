using Estudos.Viagem.Domain.Repositories;
using Estudos.Viagem.Messages.Services;

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
            return new CriarViagemOutput("Cliente não encontrado");

        var viagem = request.ToViagem();
        var validacao = viagem.Validate();
        if (!validacao.IsValid)
            return new CriarViagemOutput("Dados inválidos", validacao.Errors);

        await _viagemRepository.Save(viagem);

        if (request.HospedagemId != null)
        {
            viagem.SetReservarHotel();
            await _viagemRepository.Update(viagem);
        }

        if (request.CarroId != null)
        {
            viagem.SetAlugarCarro();
            await _viagemRepository.Update(viagem);
        }

        if (request.HospedagemId != null || request.CarroId != null)
            await _eventService.PublishAsync(request.ToEvent(viagem.Id));

        return new CriarViagemOutput();
    }
}