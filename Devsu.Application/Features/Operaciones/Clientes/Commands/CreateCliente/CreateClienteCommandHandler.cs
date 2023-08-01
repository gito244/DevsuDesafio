using AutoMapper;
using Devsu.Application.Contracts.Infrastructure;
using Devsu.Application.Contracts.Persistence;
using Devsu.Domain.Operaciones;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Devsu.Application.Features.Operaciones.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandHandler : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;
        private readonly ILogger<CreateClienteCommandHandler> _logger;

        public CreateClienteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailservice, ILogger<CreateClienteCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailservice = emailservice;
            _logger = logger;
        }

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteEntity = _mapper.Map<Cliente>(request);
            var personaEntity = _mapper.Map<Persona>(request.Persona);

            _unitOfWork.ClienteRepository.AddEntity(clienteEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el cliente.");
            }

            _logger.LogInformation($"Cliente id {clienteEntity.ClienteId} fue creado existosamente.");

            return clienteEntity.ClienteId;
        }
    }
}
