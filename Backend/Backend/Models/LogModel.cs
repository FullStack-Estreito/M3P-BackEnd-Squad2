using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Base;

namespace Backend.Models
{
	public class LogModel
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int Usuario_Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Descricao { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Detalhes { get; set; }

        // Relacionamento com BaseUsuarioModel
        public virtual BaseUsuarioModel Usuario { get; set; }
    }
}

