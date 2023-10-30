using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Exercicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64, MinimumLength = 8)]
        public string Titulo { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(255, MinimumLength = 15)]
        public string Descricao { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(30)]
        public string Materia { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR"), StringLength(10)]
        public string Data_Conclusao { get; set; }

        [Required]
        public int Professor_Id { get; set; }

        [Required]
        public int Aluno_Id { get; set; }

        // Relacionamentos
        [ForeignKey("Aluno_Id")]
        public virtual Usuario Aluno { get; set; }

        [ForeignKey("Professor_Id")]
        public virtual Usuario Professor { get; set; }
    }
}

