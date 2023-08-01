using Devsu.Application.Contracts.Persistence.Operaciones;
using Devsu.Domain.Operaciones;
using Devsu.Infrastructure.Persistence;

namespace Devsu.Infrastructure.Repositories.Operaciones
{
    public class CuentaRepository : RepositoryBase<Cuenta>, ICuentaRepository
    {
        public CuentaRepository(DevsuDbContext context) : base(context)
        {
        }
    }
}
