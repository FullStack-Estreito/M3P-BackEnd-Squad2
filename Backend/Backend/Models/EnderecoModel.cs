using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Base;

namespace Backend.Models
{
	public class EnderecoModel
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

        // Relacionamento
        public virtual BaseUsuarioModel Usuario { get; set; }

    }
}

