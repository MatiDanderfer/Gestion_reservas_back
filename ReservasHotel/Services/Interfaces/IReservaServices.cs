public interface IReservaService
{
    List<Reserva> Buscar(string nombreHuesped);
    Reserva Crear(ReservaCreateDTO reserva);
    void Eliminar(int id);
    Reserva Actualizar(int id, ReservaUpdateDTO dto);
}