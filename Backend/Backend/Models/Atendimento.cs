﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
	public class Atendimento
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "VARCHAR")]
        public string Data { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Descricao { get; set; }

        [Required]
        public int Aluno_Id { get; set; }

        [Required]
        public int Pedagogo_Id { get; set; }

        // Relacionamentos
        public virtual Aluno Aluno { get; set; }
        public virtual Pedagogo Pedagogo { get; set; }
    }
}

