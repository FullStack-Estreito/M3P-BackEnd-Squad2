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
        public string? Matricula_Aluno { get; set; }

        public int? Codigo_Registro_Professor { get; set; }

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

