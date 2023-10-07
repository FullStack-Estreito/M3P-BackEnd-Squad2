using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Usuario
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

        [Column(TypeName = "VARCHAR"), Required]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR"), Required, MinLength(6)]
        public string Senha { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Tipo { get; set; }

        [Required]
        public bool Status_Sistema { get; set; } = true;

        [Column(TypeName = "VARCHAR")]
        public string Matricula_Aluno { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Codigo_Registro_Professor { get; set; }

        [Required, ForeignKey("Empresa")]
        public int Empresa_Id { get; set; }

        [Required, ForeignKey("Endereco")]
        public int Endereco_Id { get; set; }

        // Relacionamentos
        public virtual Endereco Endereco { get; set; }
        public virtual IList<Log> Logs { get; set; }
        public virtual Empresa Empresa { get; set; }
        public virtual IList<Avaliacao> Avaliacoes { get; set; }
        public virtual IList<Exercicio> Exercicios_Alunos { get; set; }
        public virtual IList<Exercicio> Exercicios_Professores { get; set; }
        public virtual IList<Atendimento> Atendimentos_Alunos { get; set; }
        public virtual IList<Atendimento> Atendimentos_Pedagogos { get; set; }

    }
}

