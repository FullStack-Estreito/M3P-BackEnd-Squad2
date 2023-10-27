using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class Avaliacao
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(8, MinimumLength = 64)]
        public string Titulo { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(255, MinimumLength = 15)]
        public string Descricao { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Materia { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Data { get; set; }

        [Required]
        public double Pontuacao_Maxima { get; set; }

        [Required]
        public double Nota { get; set; }

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