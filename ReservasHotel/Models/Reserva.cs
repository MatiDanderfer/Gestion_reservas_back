using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("reserva")]
public class Reserva
{
    [Key]
    [Column("idreserva")]
    public int IdReserva { get; set; }
    [Column("comentarios")]
    public string? Comentarios { get; set; }
    [Column("fecha_inicio")]
    public DateTime FechaInicio { get; set; }
    [Column("fecha_fin")]
    public DateTime FechaFin { get; set; }
    [Column("cantidadpersonas")]
    public int CantidadPersonas { get; set; }
    [Column("estado")]
    public  string Estado { get; set; } = string.Empty;
    [Column("ideventogoogle")]
    public string? IdEventoGoogle { get; set; }
    [Column("monto")]
    public int Monto { get; set; }
    [Column("huesped_idhuesped")]
    public int HuespedId { get; set; }
    public  Huesped Huesped { get; set; } = null!;
}
