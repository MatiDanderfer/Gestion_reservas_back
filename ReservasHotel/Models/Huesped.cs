using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("huesped")]
public class Huesped
{
    [Key]
    [Column("idhuesped")]
    public int IdHuesped { get; set; }
    [Column("nombre")]
    public  string Nombre { get; set; } = string.Empty;
    [Column("apellido")]
    public  string Apellido { get; set; } = string.Empty;
    [Column("dni")]
    public int? Dni { get; set; }
    [Column("telefono")]
    public string? Telefono { get; set; }
    //Relacion de uno a muchos el huesped puede tener muchas reservas
    public List<Reserva>? Reservas { get; set; } = new ();

}