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
    public async Task<List<ReservaRespuestaDTO>> Buscar(string nombreHuesped)
    {
        var reservas = await _context.reservas.Include(r => r.Huesped)
            .Where(r => r.Huesped.Nombre.Contains(nombreHuesped)).ToListAsync();
        return reservas.Select(r => MapearRespuesta(r)).ToList();
    }
    // Crear una nueva reserva
    public async Task<ReservaRespuestaDTO> Crear(ReservaCreateDTO dto)
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
            Estado = dto.Estado,
            Seña = dto.Seña
        };
        _context.reservas.Add(reserva);
        await _context.SaveChangesAsync();
        await _context.Entry(reserva).Reference(r => r.Huesped).LoadAsync();
        return MapearRespuesta(reserva);
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
    public async Task<ReservaRespuestaDTO?> Actualizar(int id, ReservaUpdateDTO dto)
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
        reserva.Seña = dto.Seña;
        await _context.SaveChangesAsync();
        await _context.Entry(reserva).Reference(r => r.Huesped).LoadAsync();
        return MapearRespuesta(reserva);
    }
    // Buscar una reserva por ID
    public async Task<ReservaRespuestaDTO?> BuscarPorId(int id)
    {
        var reserva = await _context.reservas.FindAsync(id);
        if (reserva == null)
        {
            return null;
        }
        await _context.Entry(reserva).Reference(r => r.Huesped).LoadAsync();
        return MapearRespuesta(reserva);
    }

    //Listar todas las reservas
    public async Task<List<ReservaRespuestaDTO>> ListarTodas()
    {
        //comflictuaba con el pedido a la db, por eso se hizo en dos pasos
        //return await _context.reservas.Include(r => r.Huesped).Select(r => MapearRespuesta(r)).ToListAsync();
        var reservas = await _context.reservas.Include(r => r.Huesped).ToListAsync();
        return reservas.Select(r => MapearRespuesta(r)).ToList();
        
    }

    //Buscar reservas por fecha
    public async Task<List<ReservaRespuestaDTO>> BuscarPorFecha(DateTime fechaEntrada, DateTime fechaSalida)
    {
        /*return await _context.reservas.Include(r => r.Huesped)
            .Where(r => r.FechaInicio >= fechaEntrada && r.FechaFin <= fechaSalida)
            .Select(r => MapearRespuesta(r))
            .ToListAsync();*/
        var reservas = await _context.reservas.Include(r => r.Huesped)
            .Where(r => r.FechaInicio >= fechaEntrada && r.FechaFin <= fechaSalida)
            .ToListAsync();
        return reservas.Select(r => MapearRespuesta(r)).ToList();
    }

    //Buscar reservas desde una fecha de inicio
    public async Task<List<ReservaRespuestaDTO>> BuscarDesdeInicio(DateTime fechaInicio)
    {
        /*return await _context.reservas.Include(r => r.Huesped)
            .Where(r => r.FechaInicio >= fechaInicio)
            .Select(r => MapearRespuesta(r))
            .ToListAsync();*/
        var reservas = await _context.reservas.Include(r => r.Huesped)
            .Where(r => r.FechaInicio >= fechaInicio).OrderBy(r => r.FechaInicio)
            .ToListAsync();

        Console.WriteLine($"Reservas encontradas: {reservas.Count}");
        var resultado = reservas.Select(r => MapearRespuesta(r)).ToList();
        Console.WriteLine($"DTOs mapeados: {resultado.Count}");
        return resultado;
    }
    public async Task<ReservaRespuestaDTO?> CambiarEstado(int id, string nuevoEstado)
    {
        var reserva = await _context.reservas.FindAsync(id);
        if (reserva == null)
        {
            return null;
        }
        reserva.Estado = nuevoEstado;
        await _context.SaveChangesAsync();
        await _context.Entry(reserva).Reference(r => r.Huesped).LoadAsync();
        return MapearRespuesta(reserva);
    }

    //Mapeo de reserva a ReservaRespuestaDTO
    private ReservaRespuestaDTO MapearRespuesta(Reserva r) => new ReservaRespuestaDTO
    {
        IdReserva = r.IdReserva,
        FechaEntrada = r.FechaInicio,
        FechaSalida = r.FechaFin,
        CantidadPersonas = r.CantidadPersonas,
        Comentarios = r.Comentarios,
        Estado = r.Estado,
        Monto = r.Monto,
        Senia = r.Seña,
        HuespedId = r.HuespedId,
        NombreHuesped = r.Huesped?.Nombre ?? "",
        ApellidoHuesped = r.Huesped?.Apellido ?? ""
    };
}