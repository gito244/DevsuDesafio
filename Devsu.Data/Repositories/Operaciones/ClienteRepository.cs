using Devsu.Application.Contracts.Persistence.Operaciones;
using Devsu.Domain.Operaciones;
using Devsu.Infrastructure.Persistence;

namespace Devsu.Infrastructure.Repositories.Operaciones
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(DevsuDbContext context) : base(context)
        {
        }
    }
}
