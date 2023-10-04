using System;
using System.ComponentModel.DataAnnotations;
using Backend.Base;

namespace Backend.Models
{
	public class AdministradorModel : BaseUsuarioModel
	{
		[Required]
		public int Empresa_Id { get; set; }

		// Relacionamento com EmpresaModel
		public virtual EmpresaModel Empresa { get; set; }
	}
}

