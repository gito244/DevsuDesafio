using AutoMapper;
using Devsu.Application.Contracts.Persistence.Operaciones;
using Devsu.Application.Contracts.Persistence;
using Devsu.Application.Features.Operaciones.Personas.Commands.DeletePersona;
using MediatR;
using Microsoft.Extensions.Logging;
using Devsu.Application.Exceptions;
using Devsu.Domain.Operaciones;

namespace Devsu.Application.Features.Operaciones.Cuentas.Commands.DeleteCuenta
{
    public class DeleteCuentaCommandHandler : IRequestHandler<DeleteCuentaCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICuentaRepository _cuentaRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<DeletePersonaCommandHandler> _logger;

        public DeleteCuentaCommandHandler(IUnitOfWork unitOfWork, ICuentaRepository cuentaRepository, IMapper mapper, ILogger<DeletePersonaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _cuentaRepository = cuentaRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<Unit> Handle(DeleteCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuentaToDelete = await _unitOfWork.CuentaRepository.GetByIdAsync(request.NumeroCuenta);

            if (cuentaToDelete == null)
            {
                _logger.LogError($"{request.NumeroCuenta} numero de cuenta no existe en el sistema.");
                throw new NotFoundException(nameof(Cuenta), request.NumeroCuenta);
            }

            _unitOfWork.CuentaRepository.DeleteEntity(cuentaToDelete);

            await _unitOfWork.Complete();

            _logger.LogInformation($"El {request.NumeroCuenta} numero de cuenta fue eliminado con exito.");

            return Unit.Value;
        }
    }
}
