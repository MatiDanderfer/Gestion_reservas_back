public class Reserva
{
    public int IdReserva { get; set; }
    public string? Comentarios { get; set; }
    public DateTime FechaInicio { get; set; }
    public DateTime FechaFin { get; set; }
    public int CantidadPersonas { get; set; }
    public required string Estado { get; set; }
    public string? IdEventoGoogle { get; set; }
    public int Monto { get; set; }
    public int Huespedid { get; set; }
    public required Huesped Huesped { get; set; }
}
