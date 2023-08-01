using AutoMapper;
using Devsu.Application.Contracts.Persistence.Operaciones;
using Devsu.Application.Contracts.Persistence;
using Devsu.Application.Features.Operaciones.Clientes.Commands.UpdateCliente;
using MediatR;
using Microsoft.Extensions.Logging;
using Devsu.Application.Exceptions;
using Devsu.Domain.Operaciones;

namespace Devsu.Application.Features.Operaciones.Movimientos.Commands.UpdateMovimiento
{
    public class UpdateMovimientoCommandHandler : IRequestHandler<UpdateMovimientoCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovimientosRepository _movimientoRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UpdateClienteCommandHandler> _logger;

        public UpdateMovimientoCommandHandler(IUnitOfWork unitOfWork, IMovimientosRepository movimientoRepository, IMapper mapper, ILogger<UpdateClienteCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _movimientoRepository = movimientoRepository;
            _mapper = mapper;
            _logger = logger;
        }
        public async Task<Unit> Handle(UpdateMovimientoCommand request, CancellationToken cancellationToken)
        {
            var movimientoToUpdate = await _unitOfWork.MovimientosRepository.GetByIdAsync(request.MovimientoId);

            if (movimientoToUpdate == null)
            {
                _logger.LogError($"No se encontro el movimiento {request.MovimientoId}");
                throw new NotFoundException(nameof(Cliente), request.MovimientoId);
            }

            _mapper.Map(request, movimientoToUpdate, typeof(UpdateClienteCommand), typeof(Cliente));

            _unitOfWork.MovimientosRepository.UpdateEntity(movimientoToUpdate);

            await _unitOfWork.Complete();

            _logger.LogInformation($"La operacion fue exitosa actualizando el movimiento {request.MovimientoId}");

            return Unit.Value;
        }
    }
}
