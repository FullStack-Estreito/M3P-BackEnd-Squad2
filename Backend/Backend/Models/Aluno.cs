using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
	public class Aluno
	{

		
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64, MinimumLength = 8)]
        public string Nome { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Genero { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string CPF { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Telefone { get; set; }

        [Column(TypeName = "VARCHAR"), Required, EmailAddress]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MinLength(6)]
        public string Senha { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Tipo { get; set; }

        [Required]
        public bool Status_Sistema { get; set; } = true;

        [Required]
        public int Endereco_Id { get; set; }


		[Column(TypeName = "VARCHAR"), Required]
		public string Matricula { get; set; }

		// Relacionamentos
		public virtual IList<Atendimento> Atendimentos { get; set; }
        public virtual IList<Exercicio> Exercicios { get; set; }
    }
}

