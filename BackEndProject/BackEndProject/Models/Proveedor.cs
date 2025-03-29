using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebAPI.Models;
[Table("proveedor")]
public class Proveedor
{
    [Key]

    [Column("id")]
    public Guid Id { get; set; }
    public string NombreProv { get; set; }
    public string Correo { get; set; }
    public string Contacto { get; set; }
    public string Contrasena { get; set; }
    public string AnosExperiencia { get; set; }
    public string Tecnologia { get; set; }
    public int Precio { get; set; }
    public DateTime CreatedAt { get; set; }
}