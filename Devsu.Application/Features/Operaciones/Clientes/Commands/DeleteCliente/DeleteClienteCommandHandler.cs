using AutoMapper;
using Devsu.Application.Contracts.Persistence;
using Microsoft.Extensions.Logging;
using MediatR;
using Devsu.Application.Exceptions;
using Devsu.Domain.Operaciones;

namespace Devsu.Application.Features.Operaciones.Clientes.Commands.DeleteCliente
{
    public class DeleteClienteCommandHandler : IRequestHandler<DeleteClienteCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<DeleteClienteCommandHandler> _logger;

        public DeleteClienteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DeleteClienteCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var clienteToDelete = await _unitOfWork.ClienteRepository.GetByIdAsync(request.ClienteId);

            if (clienteToDelete == null)
            {
                _logger.LogError($"{request.ClienteId} cliente no existe en el sistema.");
                throw new NotFoundException(nameof(Cliente), request.ClienteId);
            }

            _unitOfWork.ClienteRepository.DeleteEntity(clienteToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.ClienteId} cliente fue eliminado con exito.");

            return Unit.Value;
        }
    }
}
