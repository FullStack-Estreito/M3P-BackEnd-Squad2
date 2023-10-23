using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class UsuarioCompleto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64, MinimumLength = 8)]
        public string Nome { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string Genero { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string CPF { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(16)]
        public string Telefone { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MinLength(2), StringLength(20)]
        public string Senha { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(20)]
        public string Tipo { get; set; }

        [Required]
        public bool Status_Sistema { get; set; } = true;

        [Column(TypeName = "VARCHAR"), StringLength(15)]
        public string Matricula_Aluno { get; set; }

        public int Codigo_Registro_Professor { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(15)]
		public string CEP { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(40)]
        public string Localidade { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(20)]
        public string UF { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(55)]
        public string Logradouro { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(8)]
        public string Numero { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(60)]
        public string? Complemento { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(65)]
        public string Bairro { get; set; }
   
    }
}