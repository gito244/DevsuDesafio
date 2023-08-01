using AutoMapper;
using Devsu.Application.Contracts.Persistence.Operaciones;
using Devsu.Application.Contracts.Persistence;
using Devsu.Application.Features.Operaciones.Personas.Commands.DeletePersona;
using MediatR;
using Microsoft.Extensions.Logging;
using Devsu.Application.Exceptions;
using Devsu.Domain.Operaciones;

namespace Devsu.Application.Features.Operaciones.Movimientos.Commands.DeleteMovimiento
{
    public class DeleteMovimientoCommandHandler : IRequestHandler<DeleteMovimientoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovimientosRepository _movimientosRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeletePersonaCommandHandler> _logger;

        public DeleteMovimientoCommandHandler(IUnitOfWork unitOfWork, IMovimientosRepository movimientosRepository, IMapper mapper, ILogger<DeletePersonaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _movimientosRepository = movimientosRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(DeleteMovimientoCommand request, CancellationToken cancellationToken)
        {
            var movimientoToDelete = await _unitOfWork.MovimientosRepository.GetByIdAsync(request.MovimientoId);

            if (movimientoToDelete == null)
            {
                _logger.LogError($"{request.MovimientoId} movimiento no existe en el sistema.");
                throw new NotFoundException(nameof(Domain.Operaciones.Movimientos), request.MovimientoId);
            }

            _unitOfWork.MovimientosRepository.DeleteEntity(movimientoToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.MovimientoId} movimiento fue eliminado con exito.");

            return Unit.Value;
        }
    }
}
