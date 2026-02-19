using Microsoft.EntityFrameworkCore;

public class ReservaService : IReservaService
{
    private readonly AppDbContext _context;

    public ReservaService(AppDbContext context)
    {
        _context = context;
    }
    // Implementación de métodos CRUD para Reserva
    // Buscar por nombre del huésped
    public List<Reserva> Buscar(string nombreHuesped)
    {
        return _context.reservas.Include(r => r.Huesped)
            .Where(r => r.Huesped.Nombre.Contains(nombreHuesped))
            .ToList();
    }
    // Crear una nueva reserva
    public Reserva Crear(ReservaCreateDTO dto)
    {
        var reserva = new Reserva
        {
            HuespedId = dto.HuespedId,
            FechaInicio = dto.FechaEntrada,
            FechaFin = dto.FechaSalida,
            CantidadPersonas = dto.CantidadPersonas,
            Comentarios = dto.Comentarios,
            Monto = dto.Monto
        };
        _context.reservas.Add(reserva);
        _context.SaveChanges();
        return reserva;
    }
    // Eliminar una reserva por ID
    public void Eliminar(int id)
    {
        var reserva = _context.reservas.Find(id);
        if (reserva != null)
        {
            _context.reservas.Remove(reserva);
            _context.SaveChanges();
        }
    }
    // Actualizar una reserva existente
    public Reserva Actualizar(int id, ReservaUpdateDTO dto)
    {
        var reserva = _context.reservas.Find(id);
        if (reserva != null)
        {
            reserva.FechaInicio = dto.FechaEntrada;
            reserva.FechaFin = dto.FechaSalida;
            reserva.CantidadPersonas = dto.CantidadPersonas;
            reserva.Comentarios = dto.Comentarios;
            reserva.Monto = dto.Monto;
            _context.SaveChanges();
        }
        return reserva;
    }
}