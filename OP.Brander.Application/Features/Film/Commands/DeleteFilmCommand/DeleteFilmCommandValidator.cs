using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OP.Brander.Application.Features.DeleteFilmCommand.Commands.DeleteFilmCommand
{
    public class DeleteFilmCommandValidator : AbstractValidator<DeleteFilmCommand>
    {
        public DeleteFilmCommandValidator()
        {
            RuleFor(p => p.Id)
               .NotEmpty().WithMessage("{PropertyName} no puede ser vacio.");
        }
    }
}