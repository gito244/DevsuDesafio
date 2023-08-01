using FluentValidation;

namespace Devsu.Application.Features.Operaciones.Clientes.Commands.CreateCliente
{
    public class CreateClienteCommandValidator : AbstractValidator<CreateClienteCommand>
    {
        public CreateClienteCommandValidator()
        {
            RuleFor(p => p.Contrasena)
                .NotEmpty().WithMessage("La {Contrasena} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Estado)
                .NotEmpty().WithMessage("El {Estado} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Persona!.Nombre)
                .NotEmpty().WithMessage("El {Persona!.Nombre} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Persona!.Genero)
                .NotEmpty().WithMessage("El {Persona!.Genero} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Persona!.Edad)
                .NotEmpty().WithMessage("La {Persona!.Edad} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Persona!.Identificacion)
                .NotEmpty().WithMessage("La {Persona!.Identificacion} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Persona!.Direccion)
                .NotEmpty().WithMessage("La {Persona!.Direccion} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Persona!.Telefono)
                .NotEmpty().WithMessage("El {Persona!.Telefono} no puede estar en blanco.")
                .NotNull();

        }
    }
}
