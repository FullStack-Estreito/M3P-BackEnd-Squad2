using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Base;

namespace Backend.Models
{
	public class AlunoModel : BaseUsuarioModel
	{
		[Column(TypeName = "VARCHAR"), Required]
		public string Matricula { get; set; }

		// Relacionamentos
		public virtual IList<AtendimentoModel> Atendimentos { get; set; }
        public virtual IList<ExercicioModel> Exercicios { get; set; }
    }
}

