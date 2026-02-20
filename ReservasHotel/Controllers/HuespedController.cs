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
    public async Task<IActionResult> Buscar(string nombre, string apellido)
    {
        var huespedes = await _huespedService.Buscar(nombre, apellido);
        return Ok(huespedes);
    }

    [HttpPost("crear")]
    public async Task<IActionResult> Crear(HuespedCreateDTO dto)
    {
        var nuevoHuesped = await _huespedService.Crear(dto);
        return Ok(nuevoHuesped);
    }

    [HttpDelete("eliminar/{id}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var existe = await _huespedService.Eliminar(id);
        if (!existe)
        {
            return NotFound($"Huésped no encontrado con id: {id}.");
        }
        return NoContent();
    }
    
    [HttpPut("actualizar/{id}")]
    public async Task<IActionResult> Actualizar(int id, HuespedUpdateDTO dto)
    {
        var huespedActualizado = await _huespedService.Actualizar(id, dto);
        if (huespedActualizado == null)
        {
            return NotFound($"Huésped no encontrado con id: {id}.");
        }
        return Ok(huespedActualizado);
    }

    [HttpGet("listar")]
    public async Task<IActionResult> ListarTodos()
    {
        var huespedes = await _huespedService.ListarTodos();
        return Ok(huespedes);
    }

    [HttpGet("buscarPorNombre")]
    public async Task<IActionResult> BuscarPorNombre(string nombre)
    {
        var huespedes = await _huespedService.BuscarPorNombre(nombre);
        return Ok(huespedes);
    }

    [HttpGet("buscarPorApellido")]
    public async Task<IActionResult> BuscarPorApellido(string apellido)
    {
        var huespedes = await _huespedService.BuscarPorApellido(apellido);
        return Ok(huespedes);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId(int id)
    {
        var huesped = await _huespedService.BuscarPorId(id);
        if (huesped == null)
        {
            return NotFound($"Huésped no encontrado con id: {id}.");
        }
        return Ok(huesped);
    }
}