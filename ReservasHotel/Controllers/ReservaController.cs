using Microsoft.AspNetCore.Mvc;
[ApiController]
[Route("api/reserva")]
public class ReservaController : ControllerBase
{
    private readonly IReservaService _reservaService;

    public ReservaController(IReservaService reservaService)
    {
        _reservaService = reservaService;
    }
    
    [HttpGet("buscar")]
    public async Task<IActionResult> Buscar(string nombreHuesped)
    {
        var reservas = await _reservaService.Buscar(nombreHuesped);
        if (reservas == null || reservas.Count == 0)
        {
            return NotFound("No se encontraron reservas para el huésped especificado.");
        }
        return Ok(reservas);
    }

    [HttpPost("crear")]
    public async Task<IActionResult> Crear(ReservaCreateDTO dto)
    {
        if (dto == null)
        {
            return BadRequest("Datos de reserva no proporcionados.");
        }
        try
        {
            var nuevaReserva = await _reservaService.Crear(dto);
            return Ok(nuevaReserva);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }
    [HttpDelete("eliminar/{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var existe = await _reservaService.Eliminar(id);
        if (!existe)
        {
            return NotFound($"Reserva no encontrada con id: {id}.");
        }
        return NoContent();
    }
    
    [HttpPut("actualizar/{id}")]
    public async Task<IActionResult> Actualizar(int id, ReservaUpdateDTO dto)
    {
        try
        {
        var reservaActualizada = await _reservaService.Actualizar(id, dto);
        if (reservaActualizada == null)
        {
            return NotFound($"Reserva no encontrada con id: {id}.");
        }
        return Ok(reservaActualizada);
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(ex.Message);
        }
    }

    [HttpGet("listar")]
    public async Task<IActionResult> ListarTodas()
    {
        var reservas = await _reservaService.ListarTodas();
        if (reservas == null || reservas.Count == 0)
        {
            return NotFound("No se encontraron reservas.");
        }
        return Ok(reservas);
    }

    [HttpGet("buscarPorFecha")]
    public async Task<IActionResult> BuscarPorFecha(DateTime fechaEntrada, DateTime fechaSalida)
   {
        if (fechaEntrada > fechaSalida)
            return BadRequest("La fecha de entrada no puede ser posterior a la fecha de salida.");
    
        var reservas = await _reservaService.BuscarPorFecha(fechaEntrada, fechaSalida);
        if (reservas == null || reservas.Count == 0)
                return NotFound("No se encontraron reservas para las fechas especificadas.");
        return Ok(reservas);
    }

    [HttpGet("buscarDesdeInicio")]
    public async Task<IActionResult> BuscarDesdeInicio(DateTime fechaInicio)
    {
        var reservas = await _reservaService.BuscarDesdeInicio(fechaInicio);
        if (reservas == null || reservas.Count == 0)
        {
            return NotFound("No se encontraron reservas desde la fecha especificada.");
        }
        return Ok(reservas);
    }
}