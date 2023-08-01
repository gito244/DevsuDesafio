using Devsu.Application.Features.Operaciones.Cuentas.Commands.CreateCuenta;
using Devsu.Application.Features.Operaciones.Cuentas.Commands.DeleteCuenta;
using Devsu.Application.Features.Operaciones.Cuentas.Commands.UpdateCuenta;
using Devsu.Application.Features.Operaciones.Cuentas.Queries.GetAllCuentasList;
using Devsu.Application.Features.Operaciones.Cuentas.Queries.GetCuentasList;
using Devsu.Application.Features.Operaciones.Cuentas.Queries.Vms;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Devsu.API.Controllers.Operaciones
{
    [Route("api/cuentas/[action]")]
    [ApiController]
    public class CuentaController : ControllerBase
    {
        private IMediator _mediator;

        public CuentaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllCuentas")]
        [ProducesResponseType(typeof(IEnumerable<CuentaWithIncludeVmResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CuentaWithIncludeVmResponse>>> GetAllCuentas()
        {
            var query = new GetAllCuentasListQuery();
            var cuentas = await _mediator.Send(query);
            return Ok(cuentas);
        }

        [HttpGet("{numeroCuenta}", Name = "GetCuentaByNumero")]
        [ProducesResponseType(typeof(IEnumerable<CuentaWithIncludeVmResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<CuentaWithIncludeVmResponse>>> GetCuentaByNumero(int numeroCuenta)
        {
            var query = new GetCuentaListQuery(numeroCuenta);
            var cuentas = await _mediator.Send(query);
            return Ok(cuentas);
        }

        [HttpPost(Name = "CreateCuenta")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateCuenta([FromBody] CreateCuentaCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateCuenta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateCuenta([FromBody] UpdateCuentaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete(Name = "DeleteCuenta")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteCuenta([FromBody] DeleteCuentaCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
