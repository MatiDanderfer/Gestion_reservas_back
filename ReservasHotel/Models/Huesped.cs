public class Huesped
{
    public int IdHuesped { get; set; }
    public  string Nombre { get; set; } = string.Empty;
    public  string Apellido { get; set; } = string.Empty;
    public int? Dni { get; set; }
    public string? Telefono { get; set; }
    //Relacion de uno a muchos el huesped puede tener muchas reservas
    public List<Reserva>? Reservas { get; set; } = new ();

}