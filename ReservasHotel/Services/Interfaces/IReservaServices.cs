public interface IReservaService
{
    Task<List<Reserva>> Buscar(string nombreHuesped);
    Task<Reserva> Crear(ReservaCreateDTO reserva);
    Task<bool> Eliminar(int id);
    Task<Reserva?> Actualizar(int id, ReservaUpdateDTO dto);
    Task<Reserva?> BuscarPorId(int id);
    Task<List<Reserva>> ListarTodas();

    Task<List<Reserva>> BuscarPorFecha(DateTime fechaEntrada, DateTime fechaSalida);
    Task<List<Reserva>> BuscarDesdeInicio(DateTime fechaInicio);
    Task<Reserva?> CambiarEstado(int id, string nuevoEstado);
}