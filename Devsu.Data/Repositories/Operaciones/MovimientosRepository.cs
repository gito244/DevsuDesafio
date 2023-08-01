using Devsu.Application.Contracts.Persistence.Operaciones;
using Devsu.Domain.Operaciones;
using Devsu.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Devsu.Infrastructure.Repositories.Operaciones
{
    public class MovimientosRepository : RepositoryBase<Movimientos>, IMovimientosRepository
    {
        public MovimientosRepository(DevsuDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<Movimientos>> GetMovimientosFechasxUsuario(DateTime fechaInicio, DateTime fechaFin, int clienteId)
        {
            var obj= await _context!.Movimientos!.Include(x => x.NumeroCuentaNavigation)
                .Include(x => x.NumeroCuentaNavigation.Cliente)
                .Include(x => x.NumeroCuentaNavigation.Cliente.Persona)
                .Where(f => f.Fecha >= fechaInicio)
                .Where(f => f.Fecha <= fechaFin)
                .ToListAsync();

            return obj;
        }

        decimal IMovimientosRepository.GetSaldoCuenta(Movimientos movimientoSaldo)
        {
            var saldoCuenta = _context!.Movimientos!
                .Where(x => x.NumeroCuenta == movimientoSaldo.NumeroCuenta)
                .OrderByDescending(x => x.MovimientoId)
                .FirstOrDefault();

            return saldoCuenta?.Saldo ?? _context.Cuentas!
                .Where(x => x.NumeroCuenta == movimientoSaldo.NumeroCuenta)
                .Select(x => x.SaldoInicial)
                .FirstOrDefault();
        }

        public decimal GetCupoDisponible(Movimientos movimientoSaldo)
        {
            var cupoDisponible = _context!.Movimientos!
                .Where(x => x.Fecha == movimientoSaldo.Fecha && x.TipoMovimiento == "retiro" && x.NumeroCuenta == movimientoSaldo.NumeroCuenta)
                .Sum(x => x.Valor)
                ;

            return Math.Abs(cupoDisponible);
        }
    }
}
