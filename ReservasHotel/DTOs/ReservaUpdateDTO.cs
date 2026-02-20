using System.ComponentModel.DataAnnotations;

public class ReservaUpdateDTO
{
    public DateTime FechaEntrada { get; set; }
    public DateTime FechaSalida { get; set; }

    [Range(1, 6, ErrorMessage = "La cantidad de personas debe ser entre 1 y 6.")]
    public int CantidadPersonas { get; set; }

    public string? Comentarios { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "El monto debe ser un valor positivo.")]
    public int Monto { get; set; }
}