using Devsu.Domain.Operaciones;

namespace Devsu.Application.Features.Operaciones.Movimientos.Queries.Vms
{
    public class MovimientosWithIncludesVm
    {
        public int MovimientoId { get; set; }
        public int NumeroCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }

        public virtual Cuenta? NumeroCuentaNavigation { get; set; } = null;
    }
}
