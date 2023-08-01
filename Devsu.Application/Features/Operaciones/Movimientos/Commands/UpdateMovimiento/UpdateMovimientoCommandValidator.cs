using FluentValidation;

namespace Devsu.Application.Features.Operaciones.Movimientos.Commands.UpdateMovimiento
{
    public class UpdateMovimientoCommandValidator : AbstractValidator<UpdateMovimientoCommand>
    {
        public UpdateMovimientoCommandValidator()
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
