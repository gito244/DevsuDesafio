using Devsu.Application.Features.Operaciones.Cuentas.Queries.Vms;
using MediatR;

namespace Devsu.Application.Features.Operaciones.Cuentas.Queries.GetCuentasList
{
    public class GetCuentaListQuery : IRequest<List<CuentaWithIncludeVmResponse>>
    {
        public GetCuentaListQuery(int cuenta)
        {
            Cuenta = cuenta;
        }

        public int Cuenta { get; set; }
    }
}
