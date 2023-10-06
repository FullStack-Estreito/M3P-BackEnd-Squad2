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

        [Column(TypeName = "VARCHAR"), Required]
		public string CEP { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Cidade { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Estado { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Logradouro { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Numero { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Complemento { get; set; }

        [Column(TypeName = "VARCHAR"), Required]
        public string Bairro { get; set; }

        [Column(TypeName = "VARCHAR")]
        public string Ponto_Referencia { get; set; }


        // Relacionamento com UsuarioModel
        public virtual Usuario Usuario { get; set; }

    }
}

