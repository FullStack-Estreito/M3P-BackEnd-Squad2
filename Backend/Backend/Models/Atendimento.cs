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
        public int id_Aluno { get; set; }

        [Required]
        public int id_Pedagogo { get; set; }

         // Relacionamentos
        [ForeignKey("id_Aluno")]
        public virtual Usuario Aluno { get; set; }

        // Define another foreign key property explicitly
        [ForeignKey("id_Pedagogo")]
        public virtual Usuario Pedagogo { get; set; }
    }
}

