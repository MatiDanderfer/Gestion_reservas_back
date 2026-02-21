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
    public async Task<List<Reserva>> Buscar(string nombreHuesped)
    {
        return await _context.reservas.Include(r => r.Huesped)
            .Where(r => r.Huesped.Nombre.Contains(nombreHuesped))
            .ToListAsync();
    }
    // Crear una nueva reserva
    public async Task<Reserva> Crear(ReservaCreateDTO dto)
    {
        var solapamiento = await _context.reservas.AnyAsync(
            r => r.FechaInicio <= dto.FechaSalida && r.FechaFin >= dto.FechaEntrada);
        if (solapamiento)
        {
            throw new InvalidOperationException("Las fechas de la reserva se solapan con otra reserva existente.");
        }
        var reserva = new Reserva
        {
            HuespedId = dto.HuespedId,
            FechaInicio = dto.FechaEntrada,
            FechaFin = dto.FechaSalida,
            CantidadPersonas = dto.CantidadPersonas,
            Comentarios = dto.Comentarios,
            Monto = dto.Monto,
            Estado = dto.Estado
        };
        _context.reservas.Add(reserva);
        await _context.SaveChangesAsync();
        return reserva;
    }
    // Eliminar una reserva por ID
    public async Task<bool> Eliminar(int id)
    {
        var reserva = await _context.reservas.FindAsync(id);
        if (reserva != null)
        {
            _context.reservas.Remove(reserva);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }
    // Actualizar una reserva existente
    public async Task<Reserva?> Actualizar(int id, ReservaUpdateDTO dto)
    {
        var reserva = await _context.reservas.FindAsync(id);
        if (reserva == null)
        {
            return null;
        }
        var solapamiento = await _context.reservas.AnyAsync(
            r => r.IdReserva != id && r.FechaInicio <= dto.FechaSalida && r.FechaFin >= dto.FechaEntrada);
        if (solapamiento){
            throw new InvalidOperationException("Las fechas de la reserva se solapan con otra reserva existente.");
        }
        reserva.FechaInicio = dto.FechaEntrada;
        reserva.FechaFin = dto.FechaSalida;
         reserva.CantidadPersonas = dto.CantidadPersonas;
        reserva.Comentarios = dto.Comentarios;
        reserva.Monto = dto.Monto;
        reserva.Estado = dto.Estado;
        await _context.SaveChangesAsync();
        return reserva;
    }
    // Buscar una reserva por ID
    public async Task<Reserva?> BuscarPorId(int id)
    {
        return await _context.reservas.FindAsync(id);
    }

    //Listar todas las reservas
    public async Task<List<Reserva>> ListarTodas()
    {
        return await _context.reservas.Include(r => r.Huesped).ToListAsync();
        
    }

    //Buscar reservas por fecha
    public async Task<List<Reserva>> BuscarPorFecha(DateTime fechaEntrada, DateTime fechaSalida)
    {
        return await _context.reservas.Include(r => r.Huesped)
            .Where(r => r.FechaInicio >= fechaEntrada && r.FechaFin <= fechaSalida)
            .ToListAsync();
    }

    //Buscar reservas desde una fecha de inicio
    public async Task<List<Reserva>> BuscarDesdeInicio(DateTime fechaInicio)
    {
        return await _context.reservas.Include(r => r.Huesped)
            .Where(r => r.FechaInicio >= fechaInicio)
            .ToListAsync();
    }
    public async Task<Reserva?> CambiarEstado(int id, string nuevoEstado)
    {
        var reserva = await _context.reservas.FindAsync(id);
        if (reserva == null)
        {
            return null;
        }
        reserva.Estado = nuevoEstado;
        await _context.SaveChangesAsync();
        return reserva;
    }
}