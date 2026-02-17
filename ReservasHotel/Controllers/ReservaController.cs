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
    /*
    [HttpGet("buscar")]
    public IActionResult Buscar(string nombreHuesped)
    {
        var reservas = _reservaService.Buscar(nombreHuesped);
        return Ok(reservas);
    }

    [HttpPost("crear")]
    public IActionResult Crear(Reserva reserva)
    {
        var nuevaReserva = _reservaService.Crear(reserva);
        return Ok(nuevaReserva);
    }

    [HttpDelete("eliminar/{id}")]
    public IActionResult Eliminar(int id)
    {
        _reservaService.Eliminar(id);
        return NoContent();
    }*/
}