using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebAPI.Models;
[Table("usuarios")]
public class Usuario
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("name")]
    public string Nombre { get; set; }
    
    [Column("email")]
    public string Correo { get; set; }
    
    [Column("password")]
    public string Contrasena { get; set; }
    
    [Column("company")]
    public string Compania { get; set; }
    
    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}