using Estudos.Viagem.Application.UseCase.ObterClientes;
using Estudos.Viagem.WebApi.Extensions;
using Estudos.Viagem.WebApi.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Estudos.Viagem.WebApi.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ClienteController : ControllerBaseCustom
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Produces(typeof(ObterClientesOutput))]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(new ObterClientesInput(), cancellationToken);
            if (output.Success)
                return Ok(output);

            return BadRequest(output);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CadastrarClienteRequest request, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(request.ToInput(), cancellationToken);
            if (output.Success)
                return Ok(output);

            return BadRequest(output);
        }
    }
}