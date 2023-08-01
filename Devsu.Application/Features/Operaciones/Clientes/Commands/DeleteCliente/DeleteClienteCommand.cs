using Devsu.Domain.Operaciones;
using MediatR;

namespace Devsu.Application.Features.Operaciones.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommand : IRequest
    {
        public int ClienteId { get; set; }
    }
}
