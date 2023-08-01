using Devsu.Domain.Common;

namespace Devsu.Domain.Operaciones
{
    public class Cliente : BaseDomainModel
    {
        public int ClienteId { get; set; }
        public int PersonaId { get; set; }
        public string Contrasena { get; set; } = string.Empty;
        public bool Estado { get; set; }

        public virtual Persona Persona { get; set; } = null!;
    }
}
