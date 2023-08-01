using Devsu.Application.Contracts.Persistence.Operaciones;
using Devsu.Domain.Common;

namespace Devsu.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        IPersonaRepository PersonaRepository { get; }
        IClienteRepository ClienteRepository { get; }
        ICuentaRepository CuentaRepository { get; }
        IMovimientosRepository MovimientosRepository { get; }
        
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;

        Task<int> Complete();
    }
}
