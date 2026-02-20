public interface IHuespedService
{
    Task<List<Huesped>> Buscar(string nombre, string apellido);
    Task<Huesped> Crear(HuespedCreateDTO dto);
    Task<bool> Eliminar(int id);
    Task<Huesped?> Actualizar(int id, HuespedUpdateDTO dto);
    Task<Huesped?> BuscarPorId(int id);
    Task<List<Huesped>> ListarTodos();
    Task<List<Huesped>> BuscarPorNombre(string nombre);
    Task<List<Huesped>> BuscarPorApellido(string apellido);
}