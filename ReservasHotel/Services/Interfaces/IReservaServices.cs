public interface IReservaService
{
    List<Reserva> Buscar(string nombreHuesped);
    Reserva Crear(Reserva reserva);
    void Eliminar(int id);
}