using System.ComponentModel.DataAnnotations;

public class HuespedUpdateDTO
{
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    [MaxLength(50, ErrorMessage = "El nombre no puede tener más de 50 caracteres.")]
    public string Nombre { get; set; }

    [Required(ErrorMessage = "El apellido es obligatorio.")]
    [MaxLength(50, ErrorMessage = "El apellido no puede tener más de 50 caracteres.")]
    public string Apellido { get; set; }

    [MaxLength(16, ErrorMessage = "El teléfono no puede tener más de 16 caracteres.")]
    public string? Telefono { get; set; }
}