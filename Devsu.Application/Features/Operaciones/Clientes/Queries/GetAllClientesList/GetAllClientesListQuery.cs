using Devsu.Application.Features.Operaciones.Clientes.Queries.Vms;
using MediatR;

namespace Devsu.Application.Features.Operaciones.Clientes.Queries.GetAllClientesList
{
    public class GetAllClientesListQuery : IRequest<List<ClienteWithIncludeVmResponse>>
    {

    }
}
