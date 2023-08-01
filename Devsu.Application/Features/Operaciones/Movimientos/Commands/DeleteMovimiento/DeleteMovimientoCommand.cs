using MediatR;

namespace Devsu.Application.Features.Operaciones.Movimientos.Commands.DeleteMovimiento
{
    public class DeleteMovimientoCommand : IRequest
    {
        public int MovimientoId { get; set; }
    }
}
