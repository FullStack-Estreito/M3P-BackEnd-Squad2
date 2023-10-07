using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
	public class Log
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, ForeignKey("Usuario")]
        public int Usuario_Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Acao { get; set; }

        [Required]
        public DateTime Data { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Detalhes { get; set; }

        // Relacionamento com UsuarioModel
        public virtual Usuario Usuario { get; set; }
    }
}

