
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;    

[ApiController]
[Route("api/testdb")]
public class TestDbControllers : ControllerBase
{
    private readonly AppDbContext _context;

    public TestDbControllers(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet("huespedes")]
    public async Task<IActionResult> GetHuespedes()
    {
        var huespedes = await _context.huespedes.ToListAsync();
        return Ok(huespedes);
    }

    [HttpGet("reservas")]
    public async Task<IActionResult> GetReservas()
    {
        var reservas = await _context.reservas.ToListAsync();
        return Ok(reservas);
    }

    [HttpGet("ping")]
    public IActionResult Ping()
    {
        return Ok(new { conectado = true });
    }
}
