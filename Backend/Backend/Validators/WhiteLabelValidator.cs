using Backend.Models;
using FluentValidation;

namespace Backend.Validators
{
    public class EmpresaValidator : AbstractValidator<Empresa>
    {
        public EmpresaValidator()
        {
            RuleFor(x => x.Nome_Empresa).NotEmpty()
                .NotNull()
                .WithMessage("O nome da empresa precisa possuir preenchimento.");

            RuleFor(x => x.Slogan).NotEmpty()
                .NotNull()
                .WithMessage("O slogan da empresa precisa possuir preenchimento.");
        }
    }
}