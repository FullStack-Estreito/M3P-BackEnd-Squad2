using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.Usuario
{
    public class UsuarioCreateDTO
    {
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public string Matricula_Aluno { get; set; }
        public int Codigo_Registro_Professor { get; set; }

        // Endereço
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Ponto_Referência { get; set; }

        // Empresa 
        public int Empresa_Id { get; set; }
    }
}