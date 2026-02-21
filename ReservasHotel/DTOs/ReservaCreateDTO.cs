using System.ComponentModel.DataAnnotations;
public class ReservaCreateDTO
{
    [Required(ErrorMessage = "El ID del huésped es obligatorio.")]
    public int HuespedId { get; set; }
    //[Required(ErrorMessage = "La fecha de entrada es obligatoria.")]
    public DateTime FechaEntrada { get; set; }
    //[Required(ErrorMessage = "La fecha de salida es obligatoria.")]
    public DateTime FechaSalida { get; set; }
    [Range(1, 6, ErrorMessage = "La cantidad de personas debe ser entre 1 y 6.")]
    public int CantidadPersonas { get; set; }
    public string? Comentarios { get; set; }
    [Range(0, int.MaxValue, ErrorMessage = "El monto debe ser un valor positivo.")]
    public int Monto { get; set; }
    public string Estado { get; set; } = "Confirmada";

}