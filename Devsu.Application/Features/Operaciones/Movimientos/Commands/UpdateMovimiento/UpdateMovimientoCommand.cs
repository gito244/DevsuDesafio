using MediatR;

namespace Devsu.Application.Features.Operaciones.Movimientos.Commands.UpdateMovimiento
{
    public class UpdateMovimientoCommand : IRequest
    {
        public int MovimientoId { get; set; }
        public int NumeroCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; } = string.Empty!;
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
    }
}
