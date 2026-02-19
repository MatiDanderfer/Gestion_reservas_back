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
        return Ok(reservas);
    }

    [HttpPost("crear")]
    public IActionResult Crear(ReservaCreateDTO dto)
    {
        var nuevaReserva = _reservaService.Crear(dto);
        return Ok(nuevaReserva);
    }

    [HttpDelete("eliminar/{id}")]
    public IActionResult Eliminar(int id)
    {
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