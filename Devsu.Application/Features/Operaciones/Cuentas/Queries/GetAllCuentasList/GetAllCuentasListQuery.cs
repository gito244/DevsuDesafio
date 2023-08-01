using Devsu.Application.Features.Operaciones.Cuentas.Queries.Vms;
using MediatR;

namespace Devsu.Application.Features.Operaciones.Cuentas.Queries.GetAllCuentasList
{
    public class GetAllCuentasListQuery : IRequest<List<CuentaWithIncludeVmResponse>>
    {
    }
}
