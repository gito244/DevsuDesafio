using MediatR;

namespace Devsu.Application.Features.Operaciones.Personas.Commands.CreatePersona
{
    public class CreatePersonaCommand : IRequest<int>
    {
        public string Nombre { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public int Edad { get; set; }
        public string Identificacion { get; set; } = string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
    }

}
