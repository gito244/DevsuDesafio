using Devsu.Application.Features.Operaciones.Movimientos.Commands.CreateMovimiento;
using Devsu.Application.Features.Operaciones.Movimientos.Commands.DeleteMovimiento;
using Devsu.Application.Features.Operaciones.Movimientos.Commands.UpdateMovimiento;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Devsu.API.Controllers.Operaciones
{
    [Route("api/movimientos/[action]")]
    [ApiController]
    public class MovimientosController : ControllerBase
    {
        private IMediator _mediator;
        public MovimientosController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateMovimiento")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> CreateMovimiento([FromBody] CreateMovimientosCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPut(Name = "UpdateMovimiento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> UpdateMovimiento([FromBody] UpdateMovimientoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete(Name = "DeleteMovimiento")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> DeleteMovimiento([FromBody] DeleteMovimientoCommand command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
