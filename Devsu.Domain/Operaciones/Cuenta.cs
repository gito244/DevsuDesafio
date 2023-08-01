using Devsu.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Devsu.Domain.Operaciones
{
    public class Cuenta : BaseDomainModel
    {
        [Key]
        public int NumeroCuenta { get; set; }
        public int ClienteId { get; set; }
        public string TipoCuenta { get; set; } = string.Empty!;
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }

        public virtual Cliente Cliente { get; set; } = null!;
    }
}
