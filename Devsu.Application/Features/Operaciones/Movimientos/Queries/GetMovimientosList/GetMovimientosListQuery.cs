using Devsu.Application.Features.Operaciones.Movimientos.Queries.Vms;
using MediatR;

namespace Devsu.Application.Features.Operaciones.Movimientos.Queries.GetMovimientosList
{
    public class GetMovimientosListQuery : IRequest<List<MovimientosWithIncludesVmResponse>>
    {
        public int Cliente { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
