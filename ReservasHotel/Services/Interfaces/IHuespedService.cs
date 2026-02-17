public interface IHuespedService
{
    List<Huesped> Buscar(string nombre, string apellido);
    Huesped Crear(Huesped huesped);
    void Eliminar(int id);
}