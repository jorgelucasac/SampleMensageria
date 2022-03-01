using Estudos.Viagem.Application.Repositories;
using Estudos.Viagem.Core.Extensions;
using Estudos.Viagem.WebApi.Extensions;
using Estudos.Viagem.WebApi.Transport;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Estudos.Viagem.WebApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class ViagensController : ControllerBaseCustom
{
    private readonly IMediator _mediator;
    private readonly IViagemRepository _viagemRepository;

    public ViagensController(IMediator mediator, IViagemRepository viagemRepository)
    {
        _mediator = mediator;
        _viagemRepository = viagemRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAsync()
    {
        var viagens = await _viagemRepository.GetAll();

        return Ok(
            viagens.Select(x => new
            {
                Id = x.Id,
                Origem = x?.Passagem.Origem,
                Destino = x?.Passagem.Destino,
                DataIda = x?.Passagem.DataIda.ToString(),
                DataVolta = x?.Passagem.DataVolta.ToString(),
                QuantidadeViajantes = x?.Passagem.QuantidadeViajantes,
                Nome = x?.Cliente.Nome,
                ClienteId = x.ClienteId,
                HospedagemId = x.HospedagemId,
                CarroId = x.CarroId,
                Total = x.Total.ToString("C"),
                Status = x.Status.GetDescription(),
                DataCadastro = x.DataCadastro.ToString(),
                DataUltimaAtualizacao = x.DataUltimaAtualizacao.ToString(),
                MensagensValidacoes = !string.IsNullOrEmpty(x.MensagensValidacoes) ? JsonConvert.DeserializeObject<List<string>>(x.MensagensValidacoes) : null
            }).ToList()
        );
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CriarViagemRequest request, CancellationToken cancellationToken)
    {
        var input = request.ToViagemInput();
        var output = await _mediator.Send(input, cancellationToken);
        if (output.Sucesso)
            return Ok(output);

        return BadRequest(output);
    }
}