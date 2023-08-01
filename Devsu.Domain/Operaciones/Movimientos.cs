using Devsu.Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Devsu.Domain.Operaciones
{
    public class Movimientos : BaseDomainModel
    {
        [Key]
        public int MovimientoId { get; set; }
        public int NumeroCuenta { get; set; }
        public DateTime Fecha { get; set; }
        public string TipoMovimiento { get; set; } = string.Empty!;
        public decimal Valor { get; set; }
        public decimal Saldo { get; set; }

        public virtual Cuenta NumeroCuentaNavigation { get; set; } = null!;
    }
}
