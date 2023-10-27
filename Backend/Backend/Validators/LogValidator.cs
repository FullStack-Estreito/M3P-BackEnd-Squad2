using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Models;
using FluentValidation;

namespace Backend.Validators
{
    public class LogValidator : AbstractValidator<Log>
    {

        public LogValidator()
        {
            RuleFor(x => x.Usuario_Id).NotEmpty()
               .NotNull()
               .WithMessage("O campo NOME possui preenchimento obrigatório.");

            RuleFor(x => x.Acao).NotEmpty()
                .NotNull()
                .WithMessage("O campo NOME possui preenchimento obrigatório.");
        }

    }
}