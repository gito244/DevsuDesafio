using FluentValidation;

namespace Devsu.Application.Features.Operaciones.Personas.Commands.UpdatePersona
{
    public class UpdatePersonaCommandValidator : AbstractValidator<UpdatePersonaCommand>
    {
        public UpdatePersonaCommandValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("El {Persona!.Nombre} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Genero)
                .NotEmpty().WithMessage("El {Persona!.Genero} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Edad)
                .NotEmpty().WithMessage("La {Persona!.Edad} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Identificacion)
                .NotEmpty().WithMessage("La {Persona!.Identificacion} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Direccion)
                .NotEmpty().WithMessage("La {Persona!.Direccion} no puede estar en blanco.")
                .NotNull();

            RuleFor(p => p.Telefono)
                .NotEmpty().WithMessage("El {Persona!.Telefono} no puede estar en blanco.")
                .NotNull();
        }
    }
}
