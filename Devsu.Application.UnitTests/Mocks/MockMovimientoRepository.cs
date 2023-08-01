using AutoFixture;
using Devsu.Domain.Operaciones;
using Devsu.Infrastructure.Persistence;

namespace Devsu.Application.UnitTests.Mocks
{
    public class MockMovimientoRepository
    {
        public static void AddDataMovimientoRepository(DevsuDbContext devsuDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var movimientos = fixture.CreateMany<Movimientos>().ToList();

            movimientos.Add(fixture.Build<Movimientos>()
                .With(tr => tr.TipoMovimiento, "retiro")
                .With(tr => tr.NumeroCuenta, 44748)
                .With(tr => tr.Fecha, DateTime.Now)
                .With(tr => tr.Valor, -200)
                .With(tr => tr.Saldo, 0)
                .Create()
            );

            devsuDbContextFake.Movimientos!.AddRange(movimientos);
            devsuDbContextFake.SaveChanges();
        }
    }
}
