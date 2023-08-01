using Devsu.Application.Features.Operaciones.Personas.Commands.CreatePersona;
using Devsu.Domain.Operaciones;
using MediatR;

namespace Devsu.Application.Features.Operaciones.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommand : IRequest
    {
        public int ClienteId { get; set; }
        public int PersonaId { get; set; }
        public string Contrasena { get; set; } = string.Empty;
        public bool Estado { get; set; }
        //public CreatePersonaCommand? Persona { get; set; }
        public Persona? persona { get; set; }
    }
}
