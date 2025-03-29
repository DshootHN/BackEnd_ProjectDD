using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppWebAPI.Models;
[Table("reserva")]
public class Reserva
{
    [Key]
    [Column("id")]
    public Guid Id { get; set; }
    public DateTime FechaInicial{ get; set; }
    public int Horas { get; set; }
    public int PrecioTotal { get; set; }
    public string Urgencia { get; set; }
    public string Contacto{ get; set; }
    public string NombreEmpresa { get; set; }
    public string NombreProveedor { get; set; }
    public string NombreCliente { get; set; }
    public DateTime CreatedAt { get; set; }
}