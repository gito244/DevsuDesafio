using Devsu.Application.Features.Operaciones.Clientes.Commands.CreateCliente;
using Devsu.Application.Features.Operaciones.Clientes.Commands.DeleteCliente;
using Devsu.Application.Features.Operaciones.Clientes.Commands.UpdateCliente;
using Devsu.Application.Features.Operaciones.Clientes.Queries.GetAllClientesList;
using Devsu.Application.Features.Operaciones.Clientes.Queries.GetClientesList;
using Devsu.Application.Features.Operaciones.Clientes.Queries.Vms;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Devsu.API.Controllers.Operaciones
{
    [Route("api/clientes/[action]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        #region Variables
        private IMediator _mediator;
        #endregion

        #region Constructor
        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }
        #endregion

        #region Methods

        [HttpGet(Name = "GetAllClientes")]
        [ProducesResponseType(typeof(IEnumerable<ClienteWithIncludeVmResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClienteWithIncludeVmResponse>>> GetAllClientes()
        {
            var query = new GetAllClientesListQuery();
            var clientes = await _mediator.Send(query);
            return Ok(clientes);
        }

        [HttpGet("{cliente}", Name = "GetClientesByCliente")]
        [ProducesResponseType(typeof(IEnumerable<ClienteWithIncludeVmResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<ClienteWithIncludeVmResponse>>> GetClientesByCliente(int cliente)
        {
            var query = new GetClienteListQuery(cliente);
            var clientes = await _mediator.Send(query);
            return Ok(clientes);
        }

        [HttpPost(Name = "CreateCliente")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCliente([FromBody] CreateClienteCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCliente([FromBody] UpdateClienteCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete(Name = "DeleteCliente")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCliente([FromBody] DeleteClienteCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        #endregion
    }
}
