using MediatR;

namespace Devsu.Application.Features.Operaciones.Cuentas.Commands.CreateCuenta
{
    public class CreateCuentaCommand : IRequest<int>
    {
        public int NumeroCuenta { get; set; }
        public int ClienteId { get; set; }
        public string TipoCuenta { get; set; } = string.Empty!;
        public decimal SaldoInicial { get; set; }
        public bool Estado { get; set; }
    }
}
