using MediatR;

namespace Devsu.Application.Features.Operaciones.Movimientos.Commands.CreateMovimiento
{
    public class CreateMovimientosCommand : IRequest<int>
    {
        public int NumeroCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; } = string.Empty!;
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }
    }
}
