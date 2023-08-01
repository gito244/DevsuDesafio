using AutoMapper;
using Devsu.Application.Constants;
using Devsu.Application.Contracts.Infrastructure;
using Devsu.Application.Contracts.Persistence;
using Devsu.Domain.Operaciones;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Linq.Expressions;
using System;

namespace Devsu.Application.Features.Operaciones.Movimientos.Commands.CreateMovimiento
{
    public class CreateMovimientosCommandHandler : IRequestHandler<CreateMovimientosCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailservice;
        private readonly ILogger<CreateMovimientosCommandHandler> _logger;
        private string Mensaje = string.Empty;

        public CreateMovimientosCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IEmailService emailservice, ILogger<CreateMovimientosCommandHandler> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _emailservice = emailservice;
            _logger = logger;
        }

        public async Task<int> Handle(CreateMovimientosCommand request, CancellationToken cancellationToken)
        {
            var moviemientosEntity = _mapper.Map<Domain.Operaciones.Movimientos>(request);

            if (!ValidacionSaldo(moviemientosEntity))
            {
                _logger.LogInformation($"No se realizó el registro debido a la siguinte validacion: {Mensaje}");
                throw new Exception($"{Mensaje}");
            }

            _unitOfWork.MovimientosRepository.AddEntity(moviemientosEntity);

            var result = await _unitOfWork.Complete();

            if (result <= 0)
            {
                throw new Exception($"No se pudo insertar el movimiento.");
            }

            _logger.LogInformation($"El movimeiento {moviemientosEntity.MovimientoId} fue creado existosamente.");

            return moviemientosEntity.MovimientoId;
        }

        private bool ValidacionSaldo(Domain.Operaciones.Movimientos movimientos)
        {
            string mensaje = string.Empty;
            bool resultado = true;

            var saldoCuenta = _unitOfWork.MovimientosRepository.GetSaldoCuenta(movimientos);
            var cupoDisponible = _unitOfWork.MovimientosRepository.GetCupoDisponible(movimientos);

            if (saldoCuenta == 0 && movimientos.TipoMovimiento == "retiro")
            {
                resultado = false;
                mensaje = $"Saldo no disponible.";
            }

            if (resultado && movimientos.TipoMovimiento == "retiro" && (cupoDisponible + Math.Abs(movimientos.Valor)) > Constantes.ValorTopeDiario)
            {
                resultado = false;
                mensaje = $"Cupo diario Excedido.";
            }

            if (!string.IsNullOrEmpty(mensaje))
            {
                Mensaje = mensaje;
            }

            return resultado;
        }
    }
}
