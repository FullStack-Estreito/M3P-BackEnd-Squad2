using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
	public class Empresa
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(50)]
	public string Nome_Empresa { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(500)]
        public string Slogan { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(50)]
        public string Paleta_Cores { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(100)]
        public string Logotipo_URL { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(50)]
        public string Demais_Infos { get; set; }

        // Relacionamento com UsuarioModel
        public virtual IList<Usuario> Usuarios { get; set; }
       
    }
}

