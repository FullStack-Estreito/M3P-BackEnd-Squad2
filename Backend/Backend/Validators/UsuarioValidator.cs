using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Backend.Models;
using FluentValidation;

namespace Backend.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(x => x.Nome).NotEmpty()
                .NotNull()
                .WithMessage("O campo NOME possui preenchimento obrigatório.")
                .Length(8, 64).WithMessage("O campo NOME deve possuir no mínimo 8 e no máximo 64 caracteres.");

            RuleFor(x => x.Genero).NotEmpty()
               .NotNull()
               .WithMessage("O campo GÊNERO possui preenchimento obrigatório.")
               .Must(Valida_Genero)
               .WithMessage("O campo GÊNERO apenas aceita os seguintes valores: 'Masculino', 'Feminino', 'Outro'.");

            RuleFor(x => x.CPF).NotEmpty()
                .NotNull()
                .WithMessage("O campo CPF possui preenchimento obrigatório.")
                .Must(Valida_CPF)
                .WithMessage("O campo CPF deve possuir o seguinte formato: 000.000.000-00");

            RuleFor(x => x.Telefone).NotEmpty()
                .NotNull()
                .WithMessage("O campo TELEFONE possui preenchimento obrigatório.")
                .Must(Valida_Telefone)
                .WithMessage("O campo TELEFONE deve possuir o seguinte formato: (99) 9 9999-99999"); ;

            RuleFor(x => x.Email).NotEmpty()
                .NotNull()
                .WithMessage("O campo EMAIL possui preenchimento obrigatório.")
                .Must(Valida_Email)
                .WithMessage("O campo EMAIL deve possuir o seguinte formato: xxxxx@xxxx.xxx");

            RuleFor(x => x.Senha).NotEmpty()
                .NotNull()
                .WithMessage("O campo NOME possui preenchimento obrigatório.")
                .Length(6).WithMessage("O campo SENHA deve possuir no mínimo 6 caracteres.");

            RuleFor(x => x.Tipo).NotEmpty()
                .NotNull()
                .WithMessage("O campo TIPO possui preenchimento obrigatório.")
                .Must(Valida_Tipo)
                .WithMessage("O campo GÊNERO apenas aceita os seguintes valores: 'Administrador', 'Pedagogo', 'Aluno', 'Professor'.");

            RuleFor(x => x.CEP).NotEmpty()
                .NotNull()
                .WithMessage("O campo CEP possui preenchimento obrigatório.");

            RuleFor(x => x.Cidade).NotEmpty()
                .NotNull()
                .WithMessage("O campo CIDADE possui preenchimento obrigatório.");

            RuleFor(x => x.UF).NotEmpty()
                .NotNull()
                .WithMessage("O campo UF possui preenchimento obrigatório.");

            RuleFor(x => x.Logradouro).NotEmpty()
                .NotNull()
                .WithMessage("O campo LOGRADOURO possui preenchimento obrigatório.");

            RuleFor(x => x.Numero).NotEmpty()
                .NotNull()
                .WithMessage("O campo NÚMERO possui preenchimento obrigatório.");

            RuleFor(x => x.Bairro).NotEmpty()
                .NotNull()
                .WithMessage("O campo NÚMERO possui preenchimento obrigatório.");

            RuleFor(x => x.Empresa_Id).NotEmpty()
                .NotNull()
                .WithMessage("O campo EMPRESA_ID possui preenchimento obrigatório.");
        }

        // Método para verificar a entrada de gênero
        private bool Valida_Genero(string genero)
        {
            if (genero == "Masculino" || genero == "Feminino" || genero == "Outro")
                return true;
            else
                return false;
        }

        // Método para verificar a entrada de tipo
        private bool Valida_Tipo(string tipo)
        {
            if (tipo == "Administrador" || tipo == "Pedagogo" || tipo == "Aluno" || tipo == "Professor")
                return true;
            else
                return false;
        }

        // Método para validar e-mail 
        private bool Valida_Email(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Método para validar formato telefone
        private bool Valida_Telefone(string telefone)
        {
            // Define uma expressão regular para validar o formato "(99) 9 9999-9999"
            string pattern = @"\(\d{2}\) 9 \d{4}-\d{4}";

            // Use Regex.IsMatch para verificar se o número de telefone corresponde ao padrão
            return Regex.IsMatch(telefone, pattern);
        }

        // Método para validar formato CPF
        private bool Valida_CPF(string cpf)
        {
            // Define uma expressão regular para validar o formato "000.000.000-00"
            string pattern = @"^\d{3}\.\d{3}\.\d{3}-\d{2}$";

            // Use Regex.IsMatch para verificar se o CPF corresponde ao padrão
            return Regex.IsMatch(cpf, pattern);
        }
    }
}