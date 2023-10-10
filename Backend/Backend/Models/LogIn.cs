using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models;

public class Login
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    
    [Column(TypeName = "VARCHAR"), Required, StringLength(64)]
    public string Email { get; set; }

    [Column(TypeName = "VARCHAR"), Required, StringLength(20)]
    public string Senha { get; set; }

}