using Estudos.Viagem.Application.UseCase.ObterViagens;
using Estudos.Viagem.WebApi.Extensions;
using Estudos.Viagem.WebApi.Responses;
using Estudos.Viagem.WebApi.Transport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Viagem.WebApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class ViagensController : ControllerBaseCustom
{
    private readonly IMediator _mediator;

    public ViagensController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Produces(typeof(ObterViagensResponse))]
    public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
    {
        var output = await _mediator.Send(new ObterViagensInput(), cancellationToken);
        if (output.Success)
            return Ok(ObterViagensResponse.OutputToResponse(output));

        return BadRequest(output);
    }

    [HttpPost]
    public async Task<IActionResult> PostAsync(CriarViagemRequest request, CancellationToken cancellationToken)
    {
        var input = request.ToViagemInput();
        var output = await _mediator.Send(input, cancellationToken);
        if (output.Success)
            return Ok(output.FormattedToApi());

        return BadRequest(output.FormattedToApi());
    }
}