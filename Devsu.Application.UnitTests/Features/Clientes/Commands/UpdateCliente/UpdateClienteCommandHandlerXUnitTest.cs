using AutoMapper;
using Devsu.Application.Contracts.Infrastructure;
using Devsu.Application.Features.Operaciones.Clientes.Commands.UpdateCliente;
using Devsu.Application.Mappings;
using Devsu.Application.UnitTests.Mock;
using Devsu.Application.UnitTests.Mocks;
using Devsu.Infrastructure.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace Devsu.Application.UnitTests.Features.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandlerXUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<UpdateClienteCommandHandler>> _logger;

        public UpdateClienteCommandHandlerXUnitTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _emailService = new Mock<IEmailService>();

            _logger = new Mock<ILogger<UpdateClienteCommandHandler>>();


            MockClienteRepository.UpdateDataClienteRepository(_unitOfWork.Object.DevsuDbContext);
        }

        [Fact]
        public async Task UpdateClienteCommand_InputStreamer_ReturnsUnit()
        {
            var ClienteInput = new UpdateClienteCommand
            {
                ClienteId = 1,
                Contrasena = "123",
                Estado = true
            };

            var handler = new UpdateClienteCommandHandler(_unitOfWork.Object, _mapper, _logger.Object);

            var result = await handler.Handle(ClienteInput, CancellationToken.None);
            
            result.ShouldBeOfType<Unit>();
        }
    }
}
