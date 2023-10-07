using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
	public class Atendimento
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Data { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Descricao { get; set; }

        [Required]
        public int Aluno_Id { get; set; }

        [Required]
        public int Pedagogo_Id { get; set; }

         // Relacionamentos
        [ForeignKey("Aluno_Id")]
        public virtual Usuario Aluno { get; set; }

        // Define another foreign key property explicitly
        [ForeignKey("Pedagogo_Id")]
        public virtual Usuario Pedagogo { get; set; }
    }
}

