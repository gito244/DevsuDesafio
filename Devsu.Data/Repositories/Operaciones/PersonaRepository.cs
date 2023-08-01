using Devsu.Application.Contracts.Persistence.Operaciones;
using Devsu.Domain.Operaciones;
using Devsu.Infrastructure.Persistence;

namespace Devsu.Infrastructure.Repositories.Operaciones
{
    public class PersonaRepository : RepositoryBase<Persona>, IPersonaRepository
    {
        public PersonaRepository(DevsuDbContext context) : base(context)
        {
        }
    }
}
