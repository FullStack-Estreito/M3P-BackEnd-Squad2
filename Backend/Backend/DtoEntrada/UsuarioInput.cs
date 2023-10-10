using System;

namespace Backend.DtoEntrada;
    public class UsuarioInput
    {
     
        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Tipo { get; set; }

        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Genero { get; set; }

        public string Senha { get; set; }


        // public bool Status_Sistema { get; set; } = true;

        public string Matricula_Aluno { get; set; }

        public int Codigo_Registro_Professor { get; set; }

        public int Empresa_Id { get; set; }

        public int Endereco_Id { get; set; }
    }