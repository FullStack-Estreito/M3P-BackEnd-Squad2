
using System;
using Backend.Models;
using FluentValidation;

namespace Backend.Validators
{
	public class AvaliacaoValidator : AbstractValidator<Avaliacao>
	{
		public AvaliacaoValidator()
		{

            RuleFor(x => x.Titulo).NotEmpty()
                .NotNull()
                .WithMessage("O campo NOME possui preenchimento obrigatório.")
                .Length(8, 64).WithMessage("O campo NOME deve possuir no mínimo 8 e no máximo 64 caracteres.");

            RuleFor(x => x.Descricao).NotEmpty()
                .NotNull()
                .WithMessage("O campo DESCRIÇÃO possui preenchimento obrigatório.")
                .Length(15, 255).WithMessage("O campo DESCRIÇÃO deve possuir no mínimo 15 e no máximo 255 caracteres.");

            RuleFor(x => x.Materia).NotEmpty()
                .NotNull()
                .WithMessage("O campo MATÉRIA possui preenchimento obrigatório.");
               
            RuleFor(x => x.Pontuacao_Maxima).NotEmpty()
                .NotNull()
                .WithMessage("O campo PONTUAÇÃO MÁXIMA possui preenchimento obrigatório.");

            RuleFor(x => x.Nota)
                .NotNull()
                .WithMessage("O campo NOTA possui preenchimento obrigatório.")
                .GreaterThanOrEqualTo(0).WithMessage("'Nota' deve ser maior ou igual a 0.");

            RuleFor(x => x.Professor_Id).NotEmpty()
                .NotNull()
                .WithMessage("O campo ID DO PROFESSOR possui preenchimento obrigatório.");

            RuleFor(x => x.Data).NotEmpty()
                .NotNull()
                .WithMessage("O campo DATA possui preenchimento obrigatório.")
                .Matches(@"^(0[1-9]|[12][0-9]|3[01])/(0[1-9]|1[0-2])/\d{4}$")
                .WithMessage("A data deve estar no formato DD/MM/AAAA.");
            
        }
    }
}

