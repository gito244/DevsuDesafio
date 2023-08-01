using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devsu.Application.Features.Operaciones.Movimientos.Commands.CreateMovimiento
{
    public class CreateMovimientosCommandValidator : AbstractValidator<CreateMovimientosCommand>
    {
        public CreateMovimientosCommandValidator()
        {
            RuleFor(p => p.NumeroCuenta)
                .NotEmpty().WithMessage("El {NumeroCuenta} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.TipoMovimiento)
                .NotEmpty().WithMessage("El {TipoMovimiento} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Fecha)
                .NotEmpty().WithMessage("La {Fecha} no puede estar en blanco.")
                .NotNull();
        }
    }
}
