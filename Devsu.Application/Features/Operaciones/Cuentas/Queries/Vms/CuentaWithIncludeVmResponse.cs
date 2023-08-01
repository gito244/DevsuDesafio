namespace Devsu.Application.Features.Operaciones.Cuentas.Queries.Vms
{
    public class CuentaWithIncludeVmResponse
    {
        public int NumeroCuenta { get; set; }
        public string? Tipo { get; set; }
        public decimal SaldoInicial { get; set; }
        public bool? Estado { get; set; }
        public string? Cliente { get; set; }
    }
}
