public interface IHuespedService
{
    List<Huesped> Buscar(string nombre, string apellido);
    Huesped Crear(HuespedCreateDTO dto);
    void Eliminar(int id);
    Huesped Actualizar(int id, HuespedUpdateDTO dto);
}