using FluentValidation;

namespace Devsu.Application.Features.Operaciones.Clientes.Commands.UpdateCliente
{
    public class UpdateClienteCommandValidator : AbstractValidator<UpdateClienteCommand>
    {
        public UpdateClienteCommandValidator() 
        {
            RuleFor(p => p.Contrasena)
                .NotEmpty().WithMessage("La {Contrasena} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Estado)
                .NotEmpty().WithMessage("El {Estado} no puede estar en blanco.")
                .NotNull();
        }
    }
}
