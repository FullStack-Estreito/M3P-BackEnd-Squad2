using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.DTO.Usuario
{
    public class UsuarioReadDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Tipo { get; set; }
        public bool Status_Sistema { get; set; } 

        // Endereço
        public string CEP { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }

    }
}