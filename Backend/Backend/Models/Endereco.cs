
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Backend.Models;

namespace Backend.Models
{
    public class Endereco
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        //teste		
        [Column(TypeName = "VARCHAR"), Required, StringLength(15)]
        public string CEP { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string Cidade { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(2)]
        public string Uf { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string Logradouro { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(7)]
        public string Numero { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string Bairro { get; set; }
        [Column(TypeName = "VARCHAR"), StringLength(64)]
        public string? Complemento { get; set; }



    }
}