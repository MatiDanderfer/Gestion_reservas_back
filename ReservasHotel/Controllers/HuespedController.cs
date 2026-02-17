using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/huesped")]
public class HuespedController : ControllerBase
{
    private readonly IHuespedService _huespedService;

    public HuespedController(IHuespedService huespedService)
    {
        _huespedService = huespedService;
    }

    [HttpGet("buscar")]
    public IActionResult Buscar(string nombre, string apellido)
    {
        var huespedes = _huespedService.Buscar(nombre, apellido);
        return Ok(huespedes);
    }

    [HttpPost("crear")]
    public IActionResult Crear(Huesped huesped)
    {
        var nuevoHuesped = _huespedService.Crear(huesped);
        return Ok(nuevoHuesped);
    }

    [HttpDelete("eliminar/{id}")]
    public IActionResult Eliminar(int id)
    {
        _huespedService.Eliminar(id);
        return NoContent();
    }
}