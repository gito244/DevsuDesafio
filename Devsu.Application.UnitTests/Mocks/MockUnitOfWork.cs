using Devsu.Infrastructure.Persistence;
using Devsu.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Devsu.Application.UnitTests.Mock
{
    public static class MockUnitOfWork
    {
       

        public static Mock<UnitOfWork> GetUnitOfWork()
        {
            Guid dbContextId = Guid.NewGuid();
            var options = new DbContextOptionsBuilder<DevsuDbContext>()
                .UseInMemoryDatabase(databaseName: $"DevsuDbContext-{dbContextId}")
                .Options;

            var devsuDbContextFake = new DevsuDbContext(options);
            devsuDbContextFake.Database.EnsureDeleted();
            var mockUnitOfWork = new Mock<UnitOfWork>(devsuDbContextFake);
                    

            return mockUnitOfWork;
        }

    }
}
