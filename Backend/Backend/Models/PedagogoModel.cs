using System;
using System.ComponentModel.DataAnnotations;
using Backend.Base;

namespace Backend.Models
{
	public class PedagogoModel : BaseUsuarioModel
    {
        // Relacionamento com AtendimentoModel
        public virtual IList<AtendimentoModel> Atendimentos { get; set; }
    }
}

