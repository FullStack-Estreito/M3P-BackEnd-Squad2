using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
	public class Endereco
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(15)]
		public string CEP { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(40)]
        public string Localidade { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(20)]
        public string UF { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(55)]
        public string Logradouro { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(8)]
        public string Numero { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(60)]
        public string? Complemento { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(65)]
        public string Bairro { get; set; }

        [Column(TypeName = "VARCHAR"), StringLength(65)]
    

        // Relacionamento com UsuarioModel
        public virtual Usuario Usuario { get; set; }

    }
}

