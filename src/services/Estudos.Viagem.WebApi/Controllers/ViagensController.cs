using Estudos.Viagem.Application.Repositories;
using Estudos.Viagem.WebApi.Extensions;
using Estudos.Viagem.WebApi.Transport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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
        return Ok(await _viagemRepository.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CriarViagemRequest input, CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(input.ToViagemInput(), cancellationToken);
        if (output.Sucesso)
            return Ok(output);

        return BadRequest(output);
    }
}