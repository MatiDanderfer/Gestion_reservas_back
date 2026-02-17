public class HuespedService
{
    private readonly AppDbContext _context;

    public HuespedService(AppDbContext context)
    {
        _context = context;
    }

    public List<Huesped> Buscar(string nombre, string apellido)
    {
        return _context.huespedes
            .Where(h => h.Nombre.Contains(nombre) && h.Apellido.Contains(apellido))
            .ToList();
    }
    public Huesped Crear(Huesped huesped)
    {
        _context.huespedes.Add(huesped);
        _context.SaveChanges();
        return huesped;
    }
    public void Eliminar(int id)
    {
        var huesped = _context.huespedes.Find(id);
        if (huesped != null)
        {
            _context.huespedes.Remove(huesped);
            _context.SaveChanges();
        }
    }
}