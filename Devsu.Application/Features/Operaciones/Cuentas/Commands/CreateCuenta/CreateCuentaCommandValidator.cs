using FluentValidation;

namespace Devsu.Application.Features.Operaciones.Cuentas.Commands.CreateCuenta
{
    public class CreateCuentaCommandValidator : AbstractValidator<CreateCuentaCommand>
    {
        public CreateCuentaCommandValidator()
        {
            RuleFor(p => p.NumeroCuenta)
                .NotEmpty().WithMessage("La {NumeroCuenta} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.TipoCuenta)
                .NotEmpty().WithMessage("La {TipoCuenta} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.SaldoInicial)
                .NotEmpty().WithMessage("La {SaldoInicial} no puede estar en blanco.")
                .NotNull()
                .When(p => p.SaldoInicial != 0);

            RuleFor(p => p.Estado)
                .NotEmpty().WithMessage("La {Estado} no puede estar en blanco.")
                .NotNull();
        }
    }
}
