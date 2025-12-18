public class Reserva
{
    public int IdReserva { get; set; }
    public string? Comentarios { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int CantidadPersonas { get; set; }
    public  string Estado { get; set; } = string.Empty;
    public string? IdEventoGoogle { get; set; }
    public int Monto { get; set; }
    public int HuespedId { get; set; }
    public  Huesped Huesped { get; set; } = null!;
}
