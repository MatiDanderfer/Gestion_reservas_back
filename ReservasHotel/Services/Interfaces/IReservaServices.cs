public interface IReservaService
{
    Task<List<ReservaRespuestaDTO>> Buscar(string nombreHuesped);
    Task<ReservaRespuestaDTO> Crear(ReservaCreateDTO reserva);
    Task<bool> Eliminar(int id);
    Task<ReservaRespuestaDTO?> Actualizar(int id, ReservaUpdateDTO dto);
    Task<ReservaRespuestaDTO?> BuscarPorId(int id);
    Task<List<ReservaRespuestaDTO>> ListarTodas();

    Task<List<ReservaRespuestaDTO>> BuscarPorFecha(DateTime fechaEntrada, DateTime fechaSalida);
    Task<List<ReservaRespuestaDTO>> BuscarDesdeInicio(DateTime fechaInicio);
    Task<ReservaRespuestaDTO?> CambiarEstado(int id, string nuevoEstado);
    
}