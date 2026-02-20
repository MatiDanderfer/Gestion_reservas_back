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
    public IActionResult Buscar(string nombreHuesped)
    {
        var reservas = _reservaService.Buscar(nombreHuesped);
        if (reservas == null || reservas.Count == 0)
        {
            return NotFound("No se encontraron reservas para el huésped especificado.");
        }
        return Ok(reservas);
    }

    [HttpPost("crear")]
    public IActionResult Crear(ReservaCreateDTO dto)
    {
        if (dto == null)
        {
            return BadRequest("Datos de reserva no proporcionados.");
        }
        var nuevaReserva = _reservaService.Crear(dto);
        return Ok(nuevaReserva);
    }

    [HttpDelete("eliminar/{id}")]
    public IActionResult Eliminar(int id)
    {
        var reserva = _reservaService.BuscarPorId(id);
        if (reserva == null)
        {
            return BadRequest("Reserva no encontrada.");
        }
        _reservaService.Eliminar(id);
        return NoContent();
    }
    
    [HttpPut("actualizar/{id}")]
    public IActionResult Actualizar(int id, ReservaUpdateDTO dto)
    {
        var reservaActualizada = _reservaService.Actualizar(id, dto);
        return Ok(reservaActualizada);
    }
}