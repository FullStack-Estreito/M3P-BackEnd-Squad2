using System;
using Backend.Models;
using FluentValidation;

namespace Backend.Validators
{
    public class AtendimentosValidator : AbstractValidator<Atendimento>
    {
        public AtendimentosValidator()
        {
            RuleFor(x => x.Data).NotEmpty()
               .NotNull()
               .WithMessage("O campo DATA possui preenchimento obrigatório.")
               .Matches(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$")
               .WithMessage("A data deve estar no formato DD/MM/AAAA.");

            RuleFor(x => x.Descricao).NotEmpty()
                .NotNull()
                .WithMessage("O campo DESCRIÇÃO possui preenchimento obrigatório.");

            RuleFor(x => x.Aluno_Id).NotEmpty()
                .NotNull()
                .WithMessage("O campo ID DO ALUNO possui preenchimento obrigatório.");

            RuleFor(x => x.Pedagogo_Id).NotEmpty()
                .NotNull()
                .WithMessage("O campo ID DO PEDAGOGO possui preenchimento obrigatório.");

           
        }
    }
}
