using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
	public class EmpresaModel
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
		public string Nome_Empresa { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Slogan { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Paleta_Cores { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Logotipo_URL { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Demais_Infos { get; set; }

        // Relacionamento com EmpresaModel
        public virtual AdministradorModel Administrador { get; set; }
    }
}

