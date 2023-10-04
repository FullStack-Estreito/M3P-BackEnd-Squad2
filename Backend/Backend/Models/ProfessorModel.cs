using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Base;

namespace Backend.Models
{
	public class ProfessorModel : BaseUsuarioModel
	{
        [Column(TypeName = "VARCHAR"), Required]
        public string Codigo_Registro_Professor { get; set; }

        // Relacionamento com ExercicioModel
        public virtual IList<ExercicioModel> Exercicios { get; set; }
    }
}

