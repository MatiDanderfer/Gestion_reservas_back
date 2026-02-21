public class ReservaRespuestaDTO
{
    public int IdReserva { get; set; }
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
    public int CantidadPersonas { get; set; }
    public string? Comentarios { get; set; }
    public string Estado { get; set; } 
    public int Monto { get; set; }
    public int Seña { get; set; }
    public int SaldoPendiente => Monto - Seña; //calculado automáticamente
    public int HuespedId { get; set; }
    public string NombreHuesped { get; set; }
    public string ApellidoHuesped { get; set; }
}