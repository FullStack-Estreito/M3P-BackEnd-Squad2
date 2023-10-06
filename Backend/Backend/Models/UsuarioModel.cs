
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models;

namespace Backend.Models
{
    public class UsuarioModel
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

        [Required]
        public int Empresa_Id { get; set; }

        [Required, ForeignKey("Endereco")]
        public int Endereco_Id { get; set; }

        // Relacionamentos
        public virtual EnderecoModel Endereco { get; set; }
        public virtual IList<LogModel> Logs { get; set; }
        public virtual EmpresaModel Empresa { get; set; }
        public virtual IList<AvaliacaoModel> Avaliacoes { get; set; }
        public virtual IList<ExercicioModel> Exercicios { get; set; }
        public virtual IList<AtendimentoModel> Atendimentos { get; set; }


    }
}

