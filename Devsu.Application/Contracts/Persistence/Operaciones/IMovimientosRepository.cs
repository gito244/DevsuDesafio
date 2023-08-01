using Devsu.Domain.Operaciones;

namespace Devsu.Application.Contracts.Persistence.Operaciones
{
    public interface IMovimientosRepository : IAsyncRepository<Movimientos>
    {
        decimal GetSaldoCuenta(Movimientos movimientoSaldo);
        decimal GetCupoDisponible(Movimientos movimientoSaldo);
        Task<IEnumerable<Movimientos>> GetMovimientosFechasxUsuario(DateTime fechaInicio, 
            DateTime fechaFin, int clienteId);
    }
}
