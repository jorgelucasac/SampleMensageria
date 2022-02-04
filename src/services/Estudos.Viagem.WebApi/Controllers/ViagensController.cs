using Estudos.Viagem.WebApi.Transport;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Viagem.WebApi.Controllers;

[ApiController]
[Route("v1/[controller]")]
public class ViagensController : ControllerBase
{
    private readonly IMediator _mediator;

    public ViagensController(IMediator mediator)
    {
        _mediator = mediator;
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