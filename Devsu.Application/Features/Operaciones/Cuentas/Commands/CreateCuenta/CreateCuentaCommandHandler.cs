using AutoMapper;
using Devsu.Application.Contracts.Infrastructure;
using Devsu.Application.Contracts.Persistence;
using Devsu.Domain.Operaciones;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Devsu.Application.Features.Operaciones.Cuentas.Commands.CreateCuenta
{
    public class CreateCuentaCommandHandler : IRequestHandler<CreateCuentaCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;
        private readonly ILogger<CreateCuentaCommandHandler> _logger;

        public CreateCuentaCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailservice, ILogger<CreateCuentaCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailservice = emailservice;
            _logger = logger;
        }

        public async Task<int> Handle(CreateCuentaCommand request, CancellationToken cancellationToken)
        {
            var cuentaEntity = _mapper.Map<Cuenta>(request);

            _unitOfWork.CuentaRepository.AddEntity(cuentaEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar la cuenta.");
            }

            _logger.LogInformation($"Numero de cuenta {cuentaEntity.NumeroCuenta} fue creado existosamente.");

            return cuentaEntity.NumeroCuenta;
        }
    }
}
