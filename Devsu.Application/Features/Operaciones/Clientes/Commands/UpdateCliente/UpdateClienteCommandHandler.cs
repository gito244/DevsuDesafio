using AutoMapper;
using Devsu.Application.Contracts.Persistence;
using Devsu.Application.Exceptions;
using Devsu.Domain.Operaciones;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Devsu.Application.Features.Operaciones.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateClienteCommandHandler> _logger;

        public UpdateClienteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<UpdateClienteCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteToUpdate = await _unitOfWork.ClienteRepository.GetByIdAsync(request.ClienteId);

            if (clienteToUpdate == null)
            {
                _logger.LogError($"No se encontro el cliente id {request.ClienteId}");
                throw new NotFoundException(nameof(Cliente), request.ClienteId);
            }

            _mapper.Map(request, clienteToUpdate, typeof(UpdateClienteCommand), typeof(Cliente));

            _unitOfWork.ClienteRepository.UpdateEntity(clienteToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el cliente {request.ClienteId}");

            return Unit.Value;
        }
    }
}
