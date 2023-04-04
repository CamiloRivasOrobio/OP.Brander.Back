using FluentValidation;

namespace OP.Brander.Application.Features.UpdateFilmCommand.Commands.UpdateFilmCommand
{
    public class UpdateFilmCommandValidator : AbstractValidator<UpdateFilmCommand>
    {
        public UpdateFilmCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Titulo)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Fecha)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Director)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Argumento)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Duracion)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Genero)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");

            RuleFor(p => p.Formato)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}