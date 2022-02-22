using Estudos.Viagem.Application.Repositories;
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
        private readonly IClienteRepository _clienteRepository;

        public ClienteController(IMediator mediator, IClienteRepository clienteRepository)
        {
            _mediator = mediator;
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            return Ok(await _clienteRepository.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(CadastrarClienteRequest request, CancellationToken cancellationToken)
        {
            var output = await _mediator.Send(request.ToInput(), cancellationToken);
            if (output.Sucesso)
                return Ok(output);

            return BadRequest(output);
        }
    }
}