using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Models
{
    public class AvaliacaoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(15, MinimumLength = 255)]
        public string Nome { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Materia { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Data { get; set; }

        [Required]
        public int Pontuacao_Maxima { get; set; }

        [Required]
        public int Nota { get; set; }

        [Required]
        public int Codigo_Professor_Id { get; set; }

        // Relacionamento com UsuarioModel
        public virtual UsuarioModel Professor { get; set; }


    }
}