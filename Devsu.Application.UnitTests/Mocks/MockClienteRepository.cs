using AutoFixture;
using Devsu.Domain.Operaciones;
using Devsu.Infrastructure.Persistence;

namespace Devsu.Application.UnitTests.Mocks
{
    public class MockClienteRepository
    {
        public static void AddDataClienteRepository(DevsuDbContext devsuDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var clientes = fixture.CreateMany<Cliente>().ToList();

            clientes.Add(fixture.Build<Cliente>()
               .With(tr => tr.Contrasena, "12345")
               .With(tr => tr.Estado, true)
               .Without(tr => tr.Persona)
               .Create()
           );

            devsuDbContextFake.Clientes!.AddRange(clientes);
            devsuDbContextFake.SaveChanges();

        }

        public static void UpdateDataClienteRepository(DevsuDbContext devsuDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var clientes = fixture.CreateMany<Cliente>().ToList();

            clientes.Add(fixture.Build<Cliente>()
               .With(tr => tr.ClienteId, 1)
               .With(tr => tr.Contrasena, "12345")
               .With(tr => tr.Estado, true)
               .Without(tr => tr.Persona)
               .Create()
           );

            devsuDbContextFake.Clientes!.AddRange(clientes);
            devsuDbContextFake.SaveChanges();

        }
        public static void DeleteDataClienteRepository(DevsuDbContext devsuDbContextFake)
        {
            var fixture = new Fixture();
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            var clientes = fixture.CreateMany<Cliente>().ToList();

            clientes.Add(fixture.Build<Cliente>()
               .With(tr => tr.ClienteId, 1)
               //.Without(tr => tr.Persona)
               .Create()
           );

            devsuDbContextFake.Clientes!.AddRange(clientes);
            devsuDbContextFake.SaveChanges();

        }
    }
}
