public class ReservaUpdateDTO
{
    public int HuespedId { get; set; }
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }
    public int CantidadPersonas { get; set; }
    public string? Comentarios { get; set; }
    public int Monto { get; set; }

}