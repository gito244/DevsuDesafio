using MediatR;

namespace Devsu.Application.Features.Operaciones.Cuentas.Commands.DeleteCuenta
{
    public class DeleteCuentaCommand : IRequest
    {
        public int NumeroCuenta { get; set; }
    }
}
