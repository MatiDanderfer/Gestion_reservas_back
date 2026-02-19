public class HuespedService : IHuespedService
{
    private readonly AppDbContext _context;

    public HuespedService(AppDbContext context)
    {
        _context = context;
    }

    // Implementación de métodos CRUD para Huesped
    // Buscar por nombre y apellido
    public List<Huesped> Buscar(string nombre, string apellido)
    {
        return _context.huespedes
            .Where(h => h.Nombre.Contains(nombre) && h.Apellido.Contains(apellido))
            .ToList();
    }
    // Crear un nuevo huésped
    public Huesped Crear(HuespedCreateDTO dto)
    {
        var huesped = new Huesped
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Telefono = dto.Telefono
        };
        _context.huespedes.Add(huesped);
        _context.SaveChanges();
        return huesped;
    }
    // Eliminar un huésped por ID
    public void Eliminar(int id)
    {
        var huesped = _context.huespedes.Find(id);
        if (huesped != null)
        {
            _context.huespedes.Remove(huesped);
            _context.SaveChanges();
        }
    }
    // Actualizar un huésped existente
    public Huesped Actualizar(int id, HuespedUpdateDTO dto)
    {
        var huesped = _context.huespedes.Find(id);
        if (huesped != null)
        {
            huesped.Nombre = dto.Nombre;
            huesped.Apellido = dto.Apellido;
            huesped.Telefono = dto.Telefono;
            _context.SaveChanges();
        }
        return huesped;
    }
}