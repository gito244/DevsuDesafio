using Devsu.Application.Features.Operaciones.Movimientos.Queries.GetMovimientosList;
using Devsu.Application.Features.Operaciones.Movimientos.Queries.Vms;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Devsu.API.Controllers.Operaciones
{
    [Route("api/reportes/[action]")]
    [ApiController]
    public class ReporteController : ControllerBase
    {
        private IMediator _mediator;

        public ReporteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetRangoMovimientoByCliente")]
        [ProducesResponseType(typeof(List<MovimientosWithIncludesVmResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<MovimientosWithIncludesVmResponse>>> GetRangoMovimientoByCliente(
                [FromQuery] GetMovimientosListQuery movimientosParams
            )
        {
            var paginationVideo = await _mediator.Send(movimientosParams);
            return Ok(paginationVideo);
        }
    }
}
