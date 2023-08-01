using AutoMapper;
using Devsu.Application.Contracts.Infrastructure;
using Devsu.Application.Features.Operaciones.Clientes.Commands.CreateCliente;
using Devsu.Application.Mappings;
using Devsu.Application.UnitTests.Mock;
using Devsu.Application.UnitTests.Mocks;
using Devsu.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Moq;
using Shouldly;
using Xunit;

namespace Devsu.Application.UnitTests.Features.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandHandlerXUnitTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<UnitOfWork> _unitOfWork;
        private readonly Mock<IEmailService> _emailService;
        private readonly Mock<ILogger<CreateClienteCommandHandler>> _logger;

        public CreateClienteCommandHandlerXUnitTest()
        {
            _unitOfWork = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _emailService = new Mock<IEmailService>();

            _logger = new Mock<ILogger<CreateClienteCommandHandler>>();


            MockClienteRepository.AddDataClienteRepository(_unitOfWork.Object.DevsuDbContext);
        }

        [Fact]
        public async Task CreateClienteCommand_InputCliente_ReturnsNumber()
        {
            var clienteInput = new CreateClienteCommand
            {
                Contrasena = "12345",
                Estado = true
            };

            var handler = new CreateClienteCommandHandler(_unitOfWork.Object, _mapper, _emailService.Object, _logger.Object);

            var result = await handler.Handle(clienteInput, CancellationToken.None);

            result.ShouldBeOfType<int>();
        }
    }
}
