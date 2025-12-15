public class Huesped
{
    public int IdHuesped { get; set; }
    public required string Nombre { get; set; }
    public required string Apellido { get; set; }
    public int? Dni { get; set; }
    public string? Telefono { get; set; }
    //Relacion de uno a muchos el huesped puede tener muchas reservas
    public List<Reserva>? Reservas { get; set; } = new ();

}