using Microsoft.EntityFrameworkCore;

public class HuespedService : IHuespedService
{
    private readonly AppDbContext _context;

    public HuespedService(AppDbContext context)
    {
        _context = context;
    }

    // Implementación de métodos CRUD para Huesped
    // Buscar por nombre y apellido
    public async Task<List<Huesped>> Buscar(string nombre, string apellido)
    {
        return await _context.huespedes
            .Where(h => h.Nombre.Contains(nombre) && h.Apellido.Contains(apellido))
            .ToListAsync();
    }
    // Crear un nuevo huésped
    public async Task<Huesped> Crear(HuespedCreateDTO dto)
    {
        var huesped = new Huesped
        {
            Nombre = dto.Nombre,
            Apellido = dto.Apellido,
            Telefono = dto.Telefono
        };
        _context.huespedes.Add(huesped);
        await _context.SaveChangesAsync();
        return huesped;
    }
    // Eliminar un huésped por ID
    public async Task<bool> Eliminar(int id)
    {
        var huesped = await _context.huespedes.FindAsync(id);
        if (huesped != null)
        {
            _context.huespedes.Remove(huesped);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    // Actualizar un huésped existente
    public async Task<Huesped?> Actualizar(int id, HuespedUpdateDTO dto)
    {
        var huesped = await _context.huespedes.FindAsync(id);
        if (huesped != null)
        {
            huesped.Nombre = dto.Nombre;
            huesped.Apellido = dto.Apellido;
            huesped.Telefono = dto.Telefono;
            await _context.SaveChangesAsync();
        }
        return huesped;
    }

    // Buscar un huésped por ID
    public async Task<Huesped?> BuscarPorId(int id)
    {
        return await _context.huespedes.FindAsync(id);
    }

    // Listar todos los huéspedes
    public async Task<List<Huesped>> ListarTodos()
    {
        return await _context.huespedes.ToListAsync();
    }
    // Buscar huéspedes por nombre
    public async Task<List<Huesped>> BuscarPorNombre(string nombre)
    {
        return await _context.huespedes
            .Where(h => h.Nombre.Contains(nombre))
            .ToListAsync();
    }
    // Buscar huéspedes por apellido
    public async Task<List<Huesped>> BuscarPorApellido(string apellido)
    {
        return await _context.huespedes
            .Where(h => h.Apellido.Contains(apellido))
            .ToListAsync();
    }
}