namespace Devsu.Application.Features.Operaciones.Movimientos.Queries.Vms
{
    public class MovimientosWithIncludesVmResponse
    {
        public string? Fecha { get; set; } = string.Empty;
        public string? Cliente { get; set; } = string.Empty;
        public int NumeroCuenta { get; set; }
        public string? Tipo { get; set; } = string.Empty;
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
        public decimal Movimiento { get; set; }
        public decimal SaldoDisponible { get; set; }
    }
}
