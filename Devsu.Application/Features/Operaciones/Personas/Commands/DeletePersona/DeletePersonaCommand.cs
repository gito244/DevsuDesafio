using MediatR;

namespace Devsu.Application.Features.Operaciones.Personas.Commands.DeletePersona
{
    public class DeletePersonaCommand : IRequest
    {
        public int PersonaId { get; set; }
    }
}
