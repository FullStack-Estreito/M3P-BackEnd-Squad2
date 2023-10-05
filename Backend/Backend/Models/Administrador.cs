using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class Administrador
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64, MinimumLength = 8)]
        public string Nome { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string Genero { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string CPF { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string Telefone { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string Email { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string Senha { get; set; }

        [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
        public string Tipo { get; set; }

        [Required]
        public bool Status_Sistema { get; set; } = true;
        public int Endereco_Id { get; set; }

        // Relacionamento com EmpresaModel

        // public virtual IList<Log> Logs { get; set; }


    }
}

